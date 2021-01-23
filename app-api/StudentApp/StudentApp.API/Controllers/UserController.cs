using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentApp.API.Common.Settings;
using StudentApp.API.DataContracts.Requests.User;
using StudentApp.API.DataContracts.Responses.User;
using StudentApp.Services.Contracts;
using HELPERS = StudentApp.Tools.Helpers;
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

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticate model)
        {
            var user = await _userService.Authenticate(model.LoginName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Nieprawidłowy login lub hasło" });

            var token = HELPERS.JwtTokenGenerator.GenerateJwtToken(user, _appSettings.Secret);

            // return basic user info and authentication token
            return Ok(new AuthenticateResponse(user, token));
        }

        [HELPERS.Authorize]
        [HttpGet("{userKey}")]
        public async Task<DC.User> GetSingle(Guid userKey)
        {
            var user = await _userService.GetSingleAsync(userKey);
            return user != null ? _mapper.Map<DC.User>(user) : null;
        }

        [HELPERS.Authorize]
        [HttpGet("all")]
        public async Task<ICollection<DC.User>> GetAllUsers()
        {
            var users = _userService.GetAllAsync().Result;
            return users != null ? _mapper.Map<ICollection<DC.User>>(users) : null;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RegisterUser([FromBody] RQ.UserPostRequest user)
        {
            RQ.UserPostValidator validator = new RQ.UserPostValidator(_userService);
            var results = await validator.ValidateAsync(user.User);

            if(results.IsValid)
            {
                var data = _userService.CreateAsync(_mapper.Map<S.User>(user), user.User.Password).Result;

                return data == 1 ? Ok() : Problem("Brak dostępu do bazy danych", null, 500);
            }

            return BadRequest(results.Errors);
        }
    }
}
