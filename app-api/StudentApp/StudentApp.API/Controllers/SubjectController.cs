using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Services.Contracts;
using DC = StudentApp.API.DataContracts;
using RQ = StudentApp.API.DataContracts.Requests.Subject.POST;
using S = StudentApp.Services.Model;
using CustomAuth = StudentApp.Tools.Helpers;

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
            _mapper = mapper;
            _semesterService = semesterService;
        }

        #region GET SINGLE
        [CustomAuth.Authorize]
        [HttpGet("{id}")]
        public async Task<DC.Subject> Get(Guid id)
        {
            var data = await _subjectService.GetSingleAsync(id);

            return data != null ? _mapper.Map<DC.Subject>(data) : null;
        }
        #endregion

        #region GET BY CURRENT SEMESTER
        [CustomAuth.Authorize]
        [HttpGet("semester")]
        public async Task<ICollection<DC.Subject>> GetByCurrentSemester()
        {
            var userData = (S.User)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var currentSemester = await _semesterService.GetCurrentSemesterByDefinitionGroupAsync(userData.SemesterDefinitionGroupKey);

            var subjects = await _subjectService.GetAllBySemesterAsync(currentSemester.DefinitionKey);
            return subjects != null ? _mapper.Map<ICollection<DC.Subject>>(subjects) : null;
        }
        #endregion

        #region POST
        [CustomAuth.Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateSubject([FromBody] RQ.SubjectPostRequest value)
        {
            RQ.SubjectPostValidator validator = new RQ.SubjectPostValidator(_subjectService);
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
        public async Task<bool> UpdateSubject(DC.Subject subject)
        {
            if (subject == null)
                throw new ArgumentNullException("subject");

            return await _subjectService.UpdateAsync(_mapper.Map<S.Subject>(subject));
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
