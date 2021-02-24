using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentApp.API.Common.Settings;
using StudentApp.API.DataContracts.Requests.User;
using StudentApp.API.DataContracts.Requests.User.PUT;
using StudentApp.API.DataContracts.Responses.User;
using StudentApp.Services.Contracts;
using CustomAuth = StudentApp.Tools.Helpers;
using SR = StudentApp.Services.Responses.User;
using S = StudentApp.Services.Model;
using DC = StudentApp.API.DataContracts;
using RQ = StudentApp.API.DataContracts.Requests.User.POST;

namespace StudentApp.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings?.Value;
        }

        #region AUTHENTICATE

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticate model)
        {
            var user = await _userService.AuthenticateAsync(model.LoginName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Nieprawidłowy login lub hasło" });

            var token = CustomAuth.JwtTokenGenerator.GenerateJwtToken(user, _appSettings.Secret);

            // return basic user info and authentication token
            return Ok(new AuthenticateResponse(user, token));
        }

        #endregion

        #region CHANGE PASSWORD

        [HttpPut("password")]
        public async Task<ActionResult> ChangePassowrd([FromBody] UserPasswordChange newPasswordModel)
        {
            var user = await _userService.GetSingleByLoginAsync(newPasswordModel.LoginName);

            if (user == null)
                return BadRequest(new { message = "Nie znaleziono użytkownika o podanym loginie" });

            UserChangePasswordValidator validator = new UserChangePasswordValidator(_userService);
            var validationResult = await validator.ValidateAsync(newPasswordModel);

            if (validationResult.IsValid)
            {
                var result = await _userService.UpdatePassword(newPasswordModel.LoginName, newPasswordModel.OldPassword,
                    newPasswordModel.NewPassword);

                if (result == -1)
                    return BadRequest("Aktualne hasło nieprawidłowe");

                return result == 1 ? Ok() : Problem("Brak dostępu do bazy danych", null, 500);
            }

            return BadRequest(validationResult.Errors);
        }

        #endregion

        #region GET SINGLE

        [CustomAuth.Authorize]
        [HttpGet("{userKey}")]
        public async Task<DC.User> GetSingle(Guid userKey)
        {
            var user = await _userService.GetSingleAsync(userKey);
            return user != null ? _mapper.Map<DC.User>(user) : null;
        }

        #endregion

        #region GET CURRENT

        [CustomAuth.Authorize]
        [HttpGet("current")]
        public async Task<DC.User> GetLogged()
        {
            var userData = (SR.UserResponse)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var user = await _userService.GetSingleAsync(userData.UserKey);

            return user != null ? _mapper.Map<DC.User>(user) : null;
        }

        #endregion

        #region GET ALL

        [CustomAuth.Authorize]
        [HttpGet("all")]
        public async Task<ICollection<DC.User>> GetAllUsers()
        {
            var users = _userService.GetAllAsync().Result;
            return users != null ? _mapper.Map<ICollection<DC.User>>(users) : null;
        }

        #endregion

        #region POST

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RegisterUser([FromBody] RQ.UserPostRequest userModel)
        {
            RQ.UserPostValidator validator = new RQ.UserPostValidator(_userService);
            var results = await validator.ValidateAsync(userModel.User);

            if (results.IsValid)
            {
                var data = await _userService.CreateAsync(_mapper.Map<S.User>(userModel), userModel.User.Password, userModel.User.SemesterValue);

                /* We want to authenticate user after registration */
                var user = await _userService.AuthenticateAsync(userModel.User.LoginName, userModel.User.Password);

                var token = CustomAuth.JwtTokenGenerator.GenerateJwtToken(user, _appSettings.Secret);

                return data == 1 ? Ok(new AuthenticateResponse(user, token)) : Problem("Brak dostępu do bazy danych", null, 500);
            }

            return BadRequest(results.Errors);
        }

        #endregion
    }
}
