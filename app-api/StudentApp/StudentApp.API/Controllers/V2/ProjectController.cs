using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.API.DataContracts.Requests.Project.GET;
using RQ = StudentApp.API.DataContracts.Requests.Project.POST;
using DC = StudentApp.API.DataContracts;
using DCProj = StudentApp.API.DataContracts.Requests.Project;
using StudentApp.Services.Contracts;
using S = StudentApp.Services.Model;
using StudentApp.Tools.Configurations;

namespace StudentApp.API.Controllers.V2
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region GET-SINGLE

        [HttpGet("{projectKey}")]
        public async Task<DC.Project> GetSingle(Guid projectKey)
        {
            var data = await _service.GetSingleAsync(projectKey);

            return data != null ? _mapper.Map<DC.Project>(data) : null;
        }

        #endregion

        [HttpGet("subject/{subjectKey}")]
        public async Task<ICollection<DC.Project>> GetAllBySubject(Guid subjectKey)
        {
            var projects = _service.GetAllBySubjectAsync(subjectKey).Result;
            return projects != null ? _mapper.Map<ICollection<DC.Project>>(projects) : null;
        }

        #region POST

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateProject([FromBody] RQ.ProjectPostRequest project)
        {
            RQ.ProjectPostValidator validator = new RQ.ProjectPostValidator(_service);
            var results = validator.Validate(project.Project);

            if (results.IsValid)
            {
                var data = await _service.CreateAsync(_mapper.Map<S.Project>(project));

                return data == 1 ? Ok() : Problem("Brak dostępu do bazy danych", null, 500);
            }

            return BadRequest(results.Errors);
        }
        #endregion

        #region GET TYPES

        [HttpGet("types")]
        public async Task<Dictionary<Guid, string>> GetTypes()
        {
            var data = await _service.GetTypesAsync();

            var pairs = data.Select(pair => new KeyValuePair<Guid, string>(pair.DefinitionKey, pair.Value));

            return pairs.ToDictionary(p => p.Key, p => p.Value);
        }

        #endregion

        #region GET STATUSES

        [HttpGet("statuses")]
        public async Task<Dictionary<Guid, string>> GetStatuses()
        {
            var data = await _service.GetAllStatusesAsync();

            var pairs = data.Select(pair => new KeyValuePair<Guid, string>(pair.StatusKey, pair.Name));

            return pairs.ToDictionary(p => p.Key, p => p.Value);
        }

        #endregion

        #region GET CATEGORIES

        [HttpGet("categories/{typeDefinitionKey}")]
        public async Task<ICollection<DC.Category>> GetCategories(Guid typeDefinitionKey)
        {
            var data = await _service.GetAllCategoriesOrderedByIndexAsync(typeDefinitionKey);

            return data != null ? _mapper.Map<ICollection<DC.Category>>(data) : null;
        }

        #endregion

        #region GET SUBJECTS

        [HttpGet("subjects")]
        public async Task<Dictionary<Guid, string>> GetSubjects()
        {
            var data = _service.GetAllSubjectsAsync();
            var pairs = data.Result.Select(pair => new KeyValuePair<Guid, string>(pair.SubjectKey, pair.Name));

            return pairs.ToDictionary(p => p.Key, p => p.Value);
        }

        #endregion
    }
}
