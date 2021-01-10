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

namespace StudentApp.API.Controllers
{
    //[ApiVersion("2.0")]
    [Route("api/subject")]
    [ApiController]

    public class SubjectController : Controller
    {
        private readonly ISubjectService _service;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region GET-SINGLE
        [HttpGet("{id}")]
        public async Task<DC.Subject> Get(Guid id)
        {
            var data = await _service.GetSingleAsync(id);

            return data != null ? _mapper.Map<DC.Subject>(data) : null;
        }
        #endregion

        #region GET-BY-SEMESTER

        [HttpGet("list/{semesterKey}")]
        public async Task<ICollection<DC.Subject>> GetBySemester(Guid semesterKey)
        {
            var subjects = await _service.GetAllBySemesterAsync(semesterKey);
            return subjects != null ? _mapper.Map<ICollection<DC.Subject>>(subjects) : null;
        }
        #endregion

        #region POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateSubject([FromBody] RQ.SubjectPostRequest value)
        {
            RQ.SubjectPostValidator validator = new RQ.SubjectPostValidator(_service);
            var results = validator.Validate(value.Subject);

            if (results.IsValid)
            {
                var data = await _service.CreateAsync(_mapper.Map<S.Subject>(value));

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

            return await _service.UpdateAsync(_mapper.Map<S.Subject>(subject));
        }
        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSubject(Guid id)
        {
            return await _service.DeleteAsync(id);
        }

        #endregion


        #region GET TYPES
        [HttpGet("types")]
        public async Task<Dictionary<Guid, string>> GetTypes()
        {
            var data = _service.GetTypes();

            var pairs = data.Result.Select(pair => new KeyValuePair<Guid, string>(pair.DefinitionKey, pair.Value));

            return pairs.ToDictionary(p => p.Key, p => p.Value);
        }

        #endregion
    }
}
