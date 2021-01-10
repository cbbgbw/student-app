using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentApp.API.DataContracts.Requests;
using StudentApp.Services.Contracts;
using S = StudentApp.Services.Model;
using User = StudentApp.API.DataContracts.User;

namespace StudentApp.API.Controllers
{
    [ApiVersion("2.0")]
    //[Route("api/v{version:apiVersion}/users")]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

#pragma warning disable CS1591
        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
#pragma warning restore CS1591

        #region GET
        /// <summary>
        /// Comments and descriptions can be added to every endpoint using XML comments.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<User> Get(Guid userKey)
        {
            var data = await _service.GetSingleAsync(userKey);

            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<User> CreateUser([FromBody] UserCreationRequest value)
        {

            //TODO: include exception management policy according to technical specifications
            if (value == null)
                throw new ArgumentNullException("value");

            if (value == null)
                throw new ArgumentNullException("value.User");


            var data = await _service.CreateAsync(_mapper.Map<S.User>(value.User));

            return data != null ? _mapper.Map<User>(data) : null;

        }
        #endregion
    }
}
