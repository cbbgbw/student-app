using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Services.Contracts;
using RQ = StudentApp.API.DataContracts.Requests.Project.POST;
using RQ_CAT = StudentApp.API.DataContracts.Requests.Category.POST;
using DC = StudentApp.API.DataContracts;
using ResponseProject = StudentApp.API.DataContracts.Responses.Project;
using S = StudentApp.Services.Model;
using SR = StudentApp.Services.Responses.User;
using CustomAuth = StudentApp.Tools.Helpers;

namespace StudentApp.API.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, ISubjectService subjectService, IMapper mapper)
        {
            _projectService = projectService;
            _subjectService = subjectService;
            _mapper = mapper;
        }

        #region GET SINGLE

        [CustomAuth.Authorize]
        [HttpGet("{projectKey}")]
        public async Task<ResponseProject.ProjectResponse> GetSingle(Guid projectKey)
        {
            var data = await _projectService.GetSingleAsync(projectKey);

            return data != null ? _mapper.Map<ResponseProject.ProjectResponse>(data) : null;
        }

        #endregion

        #region GET ALL BY SUBJECT
        [CustomAuth.Authorize]
        [HttpGet("subject/{subjectKey}")]
        public async Task<ICollection<ResponseProject.ProjectResponse>> GetAllBySubject(Guid subjectKey)
        {
            var projects = await _projectService.GetAllBySubjectAsync(subjectKey);
            return projects != null ? _mapper.Map<ICollection<ResponseProject.ProjectResponse>>(projects) : null;
        }

        #endregion

        #region GET ALL BY SEMESTER

        [CustomAuth.Authorize]
        [HttpGet("semester")]
        public async Task<ICollection<ResponseProject.ProjectResponse>> GetAllBySemester()
        {
            var userData = (SR.UserResponse)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var projects = await _projectService.GetAllProjectsInSemesterAsync(userData.CurrentSemesterDefinitionKey);

            return projects != null ? _mapper.Map<ICollection<ResponseProject.ProjectResponse>>(projects) : null;
        }

        #endregion

        #region GET ALL OPENED BY DAY

        [CustomAuth.Authorize]
        [HttpGet("day/{days:int=90}")]
        public async Task<ICollection<ResponseProject.ProjectResponse>> GetAllOpenedByDay(int days = 90)
        {
            var userData = (SR.UserResponse)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var projects = await _projectService.GetAllOpenedProjectsInSemesterByDateAsync(userData.CurrentSemesterDefinitionKey, days);

            return projects != null ? _mapper.Map<ICollection<ResponseProject.ProjectResponse>>(projects) : null;
        }

        #endregion

        #region ALL PROJECTS COUNT

        [CustomAuth.Authorize]
        [HttpGet("count")]
        public async Task<ICollection<ResponseProject.ProjectCountResponse>> GetProjectsAndExamsCount()
        {
            var userData = (SR.UserResponse)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var result = await _projectService.GetProjectAndExamCountBySemester(userData.CurrentSemesterDefinitionKey);

            return _mapper.Map<ICollection<ResponseProject.ProjectCountResponse>>(result);
        }

        #endregion

        #region PROJECT POST

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
            var userData = (SR.UserResponse)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var data = await _projectService.GetOrderedCategoriesByTypeAsync(typeDefinitionKey, userData.UserKey);

            return data != null ? _mapper.Map<ICollection<DC.Category>>(data) : null;
        }

        #endregion

        #region CATEGORY POST

        [CustomAuth.Authorize]
        [HttpPost("category")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateCategory([FromBody] RQ_CAT.CategoryPostRequest category)
        {
            var userData = (SR.UserResponse)HttpContext.Items["User"];

            var mappedCategory = _mapper.Map<S.Category>(category);
            mappedCategory.UserKey = userData.UserKey;

            RQ_CAT.CategoryPostValidator validator = new RQ_CAT.CategoryPostValidator(_projectService);
            var results = await validator.ValidateAsync(mappedCategory);

            if (results.IsValid)
            {
                var data = await _projectService.CreateCategoryAsync(mappedCategory);

                return data == 1 ? Ok() : Problem("Brak dostępu do bazy danych", null, 500);
            }

            return BadRequest(results.Errors);
        }

        #endregion

        #region DELETE

        [CustomAuth.Authorize]
        [HttpDelete("category/{categoryKey}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryKey)
        {
            var result = await _projectService.DeleteCategoryAsync(categoryKey);

            return result == 1 ? Ok() : Problem("Błąd usunięcia danych", null, 400);
        }

        #endregion
    }
}
