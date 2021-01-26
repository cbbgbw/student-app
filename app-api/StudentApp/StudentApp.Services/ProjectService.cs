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

        public async Task<Project> GetSingleAsync(Guid projectKey) => await _context.Project.SingleAsync(project => project.ProjectKey == projectKey);

        public async Task<int> CreateAsync(Project project)
        {
            await _context.Project.AddAsync(project);
            return await _context.SaveChangesAsync();

        }

        public async Task<ICollection<Project>> GetAllBySubjectAsync(Guid subjectKey) => await _context.Project.Where(proj => proj.SubjectKey == subjectKey).ToListAsync();

        //TODO przenieść typy do JSON (PROJECT_TYPES)
        public async Task<ICollection<Definition>> GetTypesAsync() => await _context.Definition.Where(d => d.GroupName == "PROJECT_TYPES").ToListAsync();

        public async Task<ICollection<Status>> GetAllStatusesAsync() => await _context.Status.ToListAsync();

        public async Task<ICollection<Category>> GetOrderedCategoriesByTypeAsync(Guid typeDefinitionKey, Guid userKey) => await _context.Category.Where(d => d.ProjectTypeKey == typeDefinitionKey && d.UserKey == userKey).OrderBy(p => p.OrderIndex).ToListAsync();

        public async Task<ICollection<Project>> GetAllProjectsInSemesterAsync(Guid semesterKey)
        {
            var projects = await _context.Subject
                .Include(s => s.Projects)
                .AsSplitQuery()
                .SingleAsync(sub => Equals(sub.SemesterDefinitionKey, semesterKey));

            return projects.Projects;
        }
    }
}
