using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Services.Contracts;
using S = StudentApp.Services.Model;
using CustomAuth = StudentApp.Tools.Helpers;

namespace StudentApp.API.Controllers
{
    [Route("api/semester")]
    [ApiController]
    public class SemesterController : Controller
    {
        private readonly ISemesterService _semesterService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public SemesterController(ISemesterService semesterService, IMapper mapper, IUserService userService)
        {
            _semesterService = semesterService;
            _mapper = mapper;
            _userService = userService;
        }

        #region GET SINGLE

        [CustomAuth.Authorize]
        [HttpGet("single/{semesterKey}")]
        public async Task<Guid> GetSingle(Guid semesterKey)
        {
            return await _semesterService.GetSingleSemesterAsync(semesterKey);
        }

        #endregion

        #region GET CURRENT

        [CustomAuth.Authorize]
        [HttpGet("current")]
        public async Task<Dictionary<Guid, string>> GetCurrentSemester()
        {
            var userData = (S.User)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var semester = await _semesterService.GetCurrentSemesterByDefinitionGroupAsync(userData.SemesterDefinitionGroupKey);

            return new Dictionary<Guid, string> { { semester.DefinitionKey, semester.Value } };
        }

        #endregion

        #region GET ALL BY USER

        [CustomAuth.Authorize]
        [HttpGet]
        public async Task<Tuple<Guid, Dictionary<Guid, string>>> GetSemestersByUser()
        {
            var userData = (S.User)HttpContext.Items["User"];
            if (userData == null)
                return null;

            var data = await _semesterService.GetAllSemestersByUserAsync(userData.UserKey);

            if(data == (null, null))
                return null;

            var firstPair = data.Item1.DefinitionKey;
            var restPairs = data.Item2.Select(pair => new KeyValuePair<Guid, string>(pair.DefinitionKey, pair.Value)).OrderBy(d => int.Parse(d.Value));

            return (firstPair, restPairs.ToDictionary(p => p.Key, p => p.Value)).ToTuple();
        }

        #endregion

        #region PUT

        [CustomAuth.Authorize]
        [HttpPut("{semesterKey}")]
        public async Task<ActionResult> ChangeSemesterContext(Guid semesterKey)
        {
            await _semesterService.ChangeSemesterAsync(semesterKey);

            return Ok();
        }

        #endregion

        #region POST

        [CustomAuth.Authorize]
        [HttpPost("{value}")]
        public async Task<Guid> CreateSemester(int value)
        {
            var userData = (S.User)HttpContext.Items["User"];

            if (userData == null)
                return Guid.Empty;

            var stringValue = value.ToString();

            return await _semesterService.CreateSemesterAsync(userData.UserKey, stringValue);
        }

        #endregion

    }
}
