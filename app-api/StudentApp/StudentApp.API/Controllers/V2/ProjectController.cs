using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RQ = StudentApp.API.DataContracts.Requests.Project.POST;
using DC = StudentApp.API.DataContracts;
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

        #region GET

        [HttpGet("{id}")]
        public async Task<DC.Project> GetSingle(Guid projectKey)
        {
            var data = await _service.GetSingleAsync(projectKey);

            return data != null ? _mapper.Map<DC.Project>(data) : null;
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<DC.Project> CreateProject([FromBody] RQ.ProjectPostRequest project)
        {
            if (project == null)
                throw new AppException("project.Project");

            var data = await _service.CreateAsync(_mapper.Map<S.Project>(project));

            return data != null ? _mapper.Map<DC.Project>(data) : null;
        }
        #endregion
    }
}
