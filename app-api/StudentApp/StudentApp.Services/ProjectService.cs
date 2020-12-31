using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentApp.API.Common.Settings;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using StudentApp.Tools.Configurations;

namespace StudentApp.Services
{
    public class ProjectService : IProjectService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProjectService(IOptions<AppSettings> settings, IMapper mapper, DataContext context)
        {
            _settings = settings?.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            if (string.IsNullOrEmpty((project.Name)))
                throw new AppException("Project Name is required");
            return project;
        }

        public async Task<Project> GetSingleAsync(Guid projectKey)
        {
            return _context.Project.SingleAsync(project => project.ProjectKey == projectKey).Result;
        }
    }
}
