using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var modifyingProject = await _context.Project.FirstOrDefaultAsync(s => s.ProjectKey == project.ProjectKey);

            modifyingProject.Name = project.Name;
            modifyingProject.TypeDefinitionKey = project.TypeDefinitionKey;
            modifyingProject.Description = project.Description;
            modifyingProject.DeadlineTime = project.DeadlineTime;
            modifyingProject.NecessaryToPass = project.NecessaryToPass;
            modifyingProject.ProjectStatusKey = project.ProjectStatusKey;
            modifyingProject.CategoryKey = project.CategoryKey;
            modifyingProject.ModifyTime = project.ModifyTime;

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

        public async Task<ICollection<R.ProjectCountResponse>> GetProjectAndExamCountBySemester(Guid semesterKey, int days)
        {
            var toDate = DateTime.Now.AddDays(days);

            var query =
                from def in _context.Definition
                join subq in
                    (from s in _context.Subject
                        join p in _context.Project on s.SubjectKey equals p.SubjectKey
                        join d in _context.Definition on p.TypeDefinitionKey equals d.DefinitionKey
                        where d.GroupName == "PROJECT_TYPES"
                              && s.SemesterDefinitionKey == semesterKey
                              && p.DeadlineTime < toDate
                     group d by d.DefinitionKey
                        into newGroup
                        select new
                        {
                            Key = newGroup.Key,
                            Count = newGroup.Count()
                        })
                    on def.DefinitionKey equals subq.Key
                select new
                {
                    subq.Key,
                    def.Value,
                    subq.Count
                };

            var data = await query.ToListAsync();
            var list = new List<R.ProjectCountResponse>();

            foreach (var item in data)
            {
                list.Add(new R.ProjectCountResponse(item.Key, item.Value, item.Count));
            }

            return list;
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
