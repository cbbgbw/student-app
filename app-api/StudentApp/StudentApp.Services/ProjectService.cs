using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using StudentApp.Tools.Configurations;

namespace StudentApp.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProjectService(IMapper mapper, DataContext context)
        {
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
            var query = from s in _context.Subject
                join p in _context.Project on s.SubjectKey equals p.SubjectKey
                where s.SemesterDefinitionKey == semesterKey
                select p;

            return await query.ToListAsync();
        }

        public async Task<ICollection<Project>> GetAllOpenedProjectsInSemesterByDateAsync(Guid semesterKey, int days)
        {
            var toDate = DateTime.Now.AddDays(days);

            var query = from s in _context.Subject
                join p in _context.Project on s.SubjectKey equals p.SubjectKey
                orderby p.DeadlineTime ascending 
                where s.SemesterDefinitionKey == semesterKey
                    && p.DeadlineTime < toDate
                    && p.ProjectStatusKey != Guid.Parse("00000000-0000-0000-0000-000000000005") //Projekt zakończony
                select p;

            return await query.ToListAsync();
        }

        public async Task<(Dictionary<Guid, int>, Dictionary<Guid, int>)> GetProjectAndExamCountBySemester(Guid semesterKey)
        {
            var all = await GetAllProjectsInSemesterAsync(semesterKey);

            var projectTypeDefinition = await _context.Definition.SingleAsync(d => d.GroupName == "PROJECT_TYPES" && d.Value == "Projekt");
            var projectTypeGuid = projectTypeDefinition.DefinitionKey;
            var projects = all.Where(p => p.TypeDefinitionKey == projectTypeGuid);
            var projectsAmount = projects.Count();
            var projectDictionary = new Dictionary<Guid, int> {{projectTypeGuid, projectsAmount}};

            var examTypeDefinition = await _context.Definition.SingleAsync(d => d.GroupName == "PROJECT_TYPES" && d.Value == "Egzamin");
            var examTypeGuid = examTypeDefinition.DefinitionKey;
            var exams = all.Where(p => p.TypeDefinitionKey == examTypeGuid);
            var examsAmount = exams.Count();
            var examDictionary = new Dictionary<Guid, int> { { examTypeGuid, examsAmount } };

            return (projectDictionary, examDictionary);
        }
    }
}
