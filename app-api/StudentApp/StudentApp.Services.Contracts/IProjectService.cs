using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S = StudentApp.Services.Model;
using R = StudentApp.Services.Responses.Project;

namespace StudentApp.Services.Contracts
{
    public interface IProjectService
    {
        Task<R.ProjectResponse> GetSingleAsync(Guid projectKey);
        Task<int> CreateAsync(S.Project project);
        Task<int> UpdateAsync(S.Project project);
        Task<ICollection<R.ProjectResponse>> GetAllBySubjectAsync(Guid subjectKey);
        Task<ICollection<R.ProjectResponse>> GetAllProjectsInSemesterAsync(Guid semesterKey);
        Task<ICollection<R.ProjectResponse>> GetAllOpenedProjectsInSemesterByDateAsync(Guid semesterKey, int days);
        Task<ICollection<R.ProjectCountResponse>> GetProjectAndExamCountBySemester(Guid semesterKey, int days);
        Task<ICollection<S.Definition>> GetTypesAsync();
        Task<ICollection<S.Status>> GetAllStatusesAsync();
        Task<ICollection<S.Category>> GetOrderedCategoriesByTypeAsync(Guid typeDefinitionKey, Guid userKey);
        Task<int> CreateCategoryAsync(S.Category category);
        Task<int> DeleteCategoryAsync(Guid categoryKey);
    }
}
