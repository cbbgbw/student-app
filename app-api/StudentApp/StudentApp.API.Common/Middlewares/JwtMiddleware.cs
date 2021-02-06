using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentApp.API.Common.Settings;
using StudentApp.Services.Contracts;

namespace StudentApp.API.Common.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings?.Value;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserService _userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachUserToContext(context, token, _userService);
                
            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, string token, IUserService _userService)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userKey = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // Dodaj do kontekstu, jeśli walidacja poprawna
                var user = await _userService.GetSingleWithCurrentSemesterAsync(userKey);

                context.Items["User"] = user;
            }
            catch
            {
                // nic nie robimy w przypadku błędu - użytkownik nie dodany do kontekstu
            }
        }
    }
}
