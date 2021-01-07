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

        public async Task<Project> GetSingleAsync(Guid projectKey)
        {
            var data = await _context.Project.SingleAsync(project => project.ProjectKey == projectKey);
            return data;
        }

        public async Task<int> CreateAsync(Project project)
        {
            await _context.Project.AddAsync(project);
            return await _context.SaveChangesAsync();

        }

        public async Task<ICollection<Project>> GetAllBySubjectAsync(Guid subjectKey) => _context.Project.Where(proj => proj.SubjectKey == subjectKey).ToList();

        //TODO przenieść typy do JSON (PROJECT_TYPES)
        public async Task<ICollection<Definition>> GetTypesAsync() =>_context.Definition.Where(d => d.GroupName == "PROJECT_TYPES").ToList();

        public async Task<ICollection<Status>> GetAllStatusesAsync() => _context.Status.ToList();

        public async Task<ICollection<Category>> GetAllCategoriesOrderedByIndexAsync(Guid typeDefinitionKey)
        {
            return _context.Category.Where(d => d.ProjectTypeKey == typeDefinitionKey).OrderBy(p => p.OrderIndex).ToList();
        }

        public async Task<ICollection<Subject>> GetAllSubjectsAsync()
        {
            return _context.Subject.ToList();
        }
    }
}
