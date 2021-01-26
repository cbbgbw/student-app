using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Services.Contracts;
using RQ = StudentApp.API.DataContracts.Requests.Project.POST;
using DC = StudentApp.API.DataContracts;
using S = StudentApp.Services.Model;
using CustomAuth = StudentApp.Tools.Helpers;

namespace StudentApp.API.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ISubjectService _subjectService;
        private readonly ISemesterService _semesterService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, ISubjectService subjectService, IMapper mapper, ISemesterService semesterService)
        {
            _projectService = projectService;
            _subjectService = subjectService;
            _semesterService = semesterService;
            _mapper = mapper;
        }

        #region GET SINGLE

        [CustomAuth.Authorize]
        [HttpGet("{projectKey}")]
        public async Task<DC.Project> GetSingle(Guid projectKey)
        {
            var data = await _projectService.GetSingleAsync(projectKey);

            return data != null ? _mapper.Map<DC.Project>(data) : null;
        }

        #endregion

        #region GET ALL BY SUBJECT
        [CustomAuth.Authorize]
        [HttpGet("subject/{subjectKey}")]
        public async Task<ICollection<DC.Project>> GetAllBySubject(Guid subjectKey)
        {
            var projects = await _projectService.GetAllBySubjectAsync(subjectKey);
            return projects != null ? _mapper.Map<ICollection<DC.Project>>(projects) : null;
        }

        #endregion

        #region GET ALL BY SEMESTER

        [CustomAuth.Authorize]
        [HttpGet("semester")]
        public async Task<ICollection<DC.Project>> GetSubjects()
        {
            var userData = (S.User)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var currentSemester = await _semesterService.GetCurrentSemesterByDefinitionGroupAsync(userData.SemesterDefinitionGroupKey);

            var projects = await _projectService.GetAllProjectsInSemesterAsync(currentSemester.DefinitionKey);

            return projects != null ? _mapper.Map<ICollection<DC.Project>>(projects) : null;
        }

        #endregion

        #region POST

        [CustomAuth.Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateProject([FromBody] RQ.ProjectPostRequest project)
        {
            RQ.ProjectPostValidator validator = new RQ.ProjectPostValidator(_projectService, _subjectService);
            var results = await validator.ValidateAsync(project.Project);

            if (results.IsValid)
            {
                var data = await _projectService.CreateAsync(_mapper.Map<S.Project>(project));

                return data == 1 ? Ok() : Problem("Brak dostępu do bazy danych", null, 500);
            }

            return BadRequest(results.Errors);
        }
        #endregion

        #region GET TYPES
        [CustomAuth.Authorize]
        [HttpGet("types")]
        public async Task<Dictionary<Guid, string>> GetTypes()
        {
            var data = await _projectService.GetTypesAsync();

            var pairs = data.Select(pair => new KeyValuePair<Guid, string>(pair.DefinitionKey, pair.Value));

            return pairs.ToDictionary(p => p.Key, p => p.Value);
        }

        #endregion

        #region GET STATUSES

        [CustomAuth.Authorize]
        [HttpGet("statuses")]
        public async Task<Dictionary<Guid, string>> GetStatuses()
        {
            var data = await _projectService.GetAllStatusesAsync();

            var pairs = data.Select(pair => new KeyValuePair<Guid, string>(pair.StatusKey, pair.Name));

            return pairs.ToDictionary(p => p.Key, p => p.Value);
        }

        #endregion

        #region GET CATEGORIES

        [CustomAuth.Authorize]
        [HttpGet("categories/{typeDefinitionKey}")]
        public async Task<ICollection<DC.Category>> GetCategories(Guid typeDefinitionKey)
        {
            var userData = (S.User)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var data = await _projectService.GetOrderedCategoriesByTypeAsync(typeDefinitionKey, userData.UserKey);

            return data != null ? _mapper.Map<ICollection<DC.Category>>(data) : null;
        }

        #endregion

    }
}
