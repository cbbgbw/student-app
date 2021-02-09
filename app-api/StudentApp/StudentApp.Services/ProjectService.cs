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
using R = StudentApp.Services.Responses.Project;

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

        public async Task<int> CreateAsync(Project project)
        {
            await _context.Project.AddAsync(project);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Project project)
        {
            _context.Project.Update(project);
            return await _context.SaveChangesAsync();
        }

        public async Task<R.ProjectResponse> GetSingleAsync(Guid projectKey)
        {
            var query = from p in _context.Project
                join subject in _context.Subject on p.SubjectKey equals subject.SubjectKey
                join dt in _context.Definition on p.TypeDefinitionKey equals dt.DefinitionKey
                join c in _context.Category on p.CategoryKey equals c.CategoryKey
                join status in _context.Status on p.ProjectStatusKey equals status.StatusKey
                where p.ProjectKey == projectKey
                select new
                {
                    p,
                    subjectName = subject.Name,
                    typeDefinitionName = dt.Value,
                    categoryName = c.CategoryName,
                    statusName = status.Name
                };

            var project = await query.FirstOrDefaultAsync();

            return new R.ProjectResponse(project.p, project.typeDefinitionName, project.statusName,
                project.categoryName, project.subjectName);
        }

        public async Task<ICollection<R.ProjectResponse>> GetAllBySubjectAsync(Guid subjectKey)
        {
            var query = from p in _context.Project
                join subject in _context.Subject on p.SubjectKey equals subject.SubjectKey
                join dt in _context.Definition on p.TypeDefinitionKey equals dt.DefinitionKey
                join c in _context.Category on p.CategoryKey equals c.CategoryKey
                join status in _context.Status on p.ProjectStatusKey equals status.StatusKey
                where subject.SubjectKey == subjectKey
                select new
                {
                    p,
                    subjectName = subject.Name,
                    typeDefinitionName = dt.Value,
                    categoryName = c.CategoryName,
                    statusName = status.Name
                };

            var projects = new List<R.ProjectResponse>();

            var data = await query.ToListAsync();

            foreach (var item in data)
            {
                projects.Add(new R.ProjectResponse(item.p, item.typeDefinitionName, item.statusName, item.categoryName, item.subjectName));
            }

            return projects;
        }

        public async Task<ICollection<R.ProjectResponse>> GetAllProjectsInSemesterAsync(Guid semesterKey)
        {
            var query = from p in _context.Project
                join subject in _context.Subject on p.SubjectKey equals subject.SubjectKey
                join dt in _context.Definition on p.TypeDefinitionKey equals dt.DefinitionKey
                join c in _context.Category on p.CategoryKey equals c.CategoryKey
                join status in _context.Status on p.ProjectStatusKey equals status.StatusKey
                where subject.SemesterDefinitionKey == semesterKey
                select new
                {
                    p,
                    subjectName = subject.Name,
                    typeDefinitionName = dt.Value,
                    categoryName = c.CategoryName,
                    statusName = status.Name
                };

            var projects = new List<R.ProjectResponse>();

            var data = await query.ToListAsync();

            foreach (var item in data)
            {
                projects.Add(new R.ProjectResponse(item.p, item.typeDefinitionName, item.statusName, item.categoryName, item.subjectName));
            }

            return projects;
        }

        public async Task<ICollection<R.ProjectResponse>> GetAllOpenedProjectsInSemesterByDateAsync(Guid semesterKey, int days)
        {
            var toDate = DateTime.Now.AddDays(days);

            var query = from p in _context.Project
                join subject in _context.Subject on p.SubjectKey equals subject.SubjectKey
                join dt in _context.Definition on p.TypeDefinitionKey equals dt.DefinitionKey
                join c in _context.Category on p.CategoryKey equals c.CategoryKey
                join status in _context.Status on p.ProjectStatusKey equals status.StatusKey
                where subject.SemesterDefinitionKey == semesterKey
                    && p.DeadlineTime < toDate
                select new
                {
                    p,
                    subjectName = subject.Name,
                    typeDefinitionName = dt.Value,
                    categoryName = c.CategoryName,
                    statusName = status.Name
                };

            var projects = new List<R.ProjectResponse>();

            var data = await query.ToListAsync();

            foreach (var item in data)
            {
                projects.Add(new R.ProjectResponse(item.p, item.typeDefinitionName, item.statusName, item.categoryName, item.subjectName));
            }

            return projects;
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

        /* Metody pomocnicze */
        public async Task<ICollection<Definition>> GetTypesAsync() => await _context.Definition.Where(d => d.GroupName == "PROJECT_TYPES").ToListAsync();

        public async Task<ICollection<Status>> GetAllStatusesAsync() => await _context.Status.ToListAsync();

        public async Task<ICollection<Category>> GetOrderedCategoriesByTypeAsync(Guid typeDefinitionKey, Guid userKey)
        {
            return await _context.Category.
                Where(d => d.ProjectTypeKey == typeDefinitionKey 
                           && (d.UserKey == userKey || d.UserKey == Guid.Parse("00000000-0000-0000-0000-FFFFFFFFFFFF"))).OrderBy(p => p.OrderIndex).ToListAsync();
        } 

        public async Task<int> CreateCategoryAsync(Category category)
        {
            var maxOrderIndex = await _context.Category.OrderByDescending(c => c.OrderIndex).FirstAsync();

            category.OrderIndex = maxOrderIndex.OrderIndex + 1;

            await _context.Category.AddAsync(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCategoryAsync(Guid categoryKey)
        {
            var category = await _context.Category.FindAsync(categoryKey);

            if (category != null)
            {
                _context.Category.Remove(category);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }
    }
}
