﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Services.Model;

namespace StudentApp.Services.Contracts
{
    public interface IProjectService
    {
        Task<Project> GetSingleAsync(Guid projectKey);
        Task<int> CreateAsync(Project project);
        Task<ICollection<Project>> GetAllBySubjectAsync(Guid subjectKey);
        Task<ICollection<Definition>> GetTypesAsync();
        Task<ICollection<Status>> GetAllStatusesAsync();
        Task<ICollection<Category>> GetAllCategoriesOrderedByIndexAsync(Guid typeDefinitionKey);
        //Task<ICollection<Subject>> GetAllSubjectsAsync();
        Task<ICollection<Project>> GetAllProjectsInSemester(Guid semesterKey);

    }
}
