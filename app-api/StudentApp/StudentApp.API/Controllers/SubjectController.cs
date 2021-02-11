using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Services.Contracts;
using DC = StudentApp.API.DataContracts;
using RQ_POST = StudentApp.API.DataContracts.Requests.Subject.POST;
using RQ_PUT = StudentApp.API.DataContracts.Requests.Subject.PUT;
using S = StudentApp.Services.Model;
using SR = StudentApp.Services.Responses.User;
using CustomAuth = StudentApp.Tools.Helpers;

using Responses = StudentApp.API.DataContracts.Responses.Subject;

namespace StudentApp.API.Controllers
{
    //[ApiVersion("2.0")]
    [Route("api/subject")]
    [ApiController]

    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly ISemesterService _semesterService;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService subjectService, IMapper mapper, ISemesterService semesterService)
        {
            _subjectService = subjectService;
            _semesterService = semesterService;
            _mapper = mapper;
        }

        #region GET SINGLE
        [CustomAuth.Authorize]
        [HttpGet("{id}")]
        public async Task<Responses.SubjectResponse> Get(Guid id)
        {
            var data = await _subjectService.GetSingleAsync(id);

            return data != null ? _mapper.Map<Responses.SubjectResponse>(data) : null;
        }
        #endregion

        #region GET BY CURRENT SEMESTER
        [CustomAuth.Authorize]
        [HttpGet("semester")]
        public async Task<ICollection<Responses.SubjectResponse>> GetByCurrentSemester()
        {
            var userData = (SR.UserResponse)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var subjects = await _subjectService.GetAllBySemesterAsync(userData.CurrentSemesterDefinitionKey);
            return subjects != null ? _mapper.Map<ICollection<Responses.SubjectResponse>>(subjects) : null;
        }
        #endregion

        #region GET SUBJECTS COUNT

        [CustomAuth.Authorize]
        [HttpGet("count")]
        public async Task<int> GetProjectsAndExamsCount()
        {
            var userData = (SR.UserResponse)HttpContext.Items["User"];

            if (userData == null)
                return 0;

            var result = await _subjectService.GetSubjectCountBySemester(userData.CurrentSemesterDefinitionKey);

            return result;
        }

        #endregion

        #region POST
        [CustomAuth.Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateSubject([FromBody] RQ_POST.SubjectPostRequest value)
        {
            RQ_POST.SubjectPostValidator validator = new RQ_POST.SubjectPostValidator(_subjectService);
            var results = await validator.ValidateAsync(value.Subject);

            if (results.IsValid)
            {
                var data = await _subjectService.CreateAsync(_mapper.Map<S.Subject>(value));

                return data == 1 ? Ok() : Problem("Brak dostępu do db", null, 500);
            }
            return BadRequest(results.Errors);
        }
        #endregion

        #region PUT

        [HttpPut]
        public async Task<ActionResult> UpdateSubject([FromBody] RQ_PUT.SubjectPutRequest subject)
        {
            RQ_PUT.SubjectPutValidator validator = new RQ_PUT.SubjectPutValidator(_subjectService);
            var results = await validator.ValidateAsync(subject.Subject);

            if (results.IsValid)
            {
                var data = await _subjectService.UpdateAsync(_mapper.Map<S.Subject>(subject));

                return data == 1 ? Ok() : Problem("Brak dostępu do db", null, 500);
            }
            return BadRequest(results.Errors);
        }
        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSubject(Guid id)
        {
            return await _subjectService.DeleteAsync(id);
        }

        #endregion

        #region GET TYPES
        [CustomAuth.Authorize]
        [HttpGet("types")]
        public async Task<Dictionary<Guid, string>> GetTypes()
        {
            var data = await _subjectService.GetTypesAsync();

            var pairs = data.Select(pair => new KeyValuePair<Guid, string>(pair.DefinitionKey, pair.Value));

            return pairs.ToDictionary(p => p.Key, p => p.Value);
        }

        #endregion
    }
}
