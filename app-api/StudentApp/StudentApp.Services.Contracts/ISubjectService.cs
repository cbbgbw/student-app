using StudentApp.Services.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using R = StudentApp.Services.Responses.Subject;

namespace StudentApp.Services.Contracts
{
    public interface ISubjectService
    {
        Task<R.SubjectResponse> GetSingleAsync(Guid subjectKey);
        Task<int> CreateAsync(Subject subject);
        Task<int> UpdateAsync(Subject subject);
        Task<bool> DeleteAsync(Guid subjectKey);
        Task<ICollection<R.SubjectResponse>> GetAllBySemesterAsync(Guid semesterKey);
        Task<int> GetSubjectCountBySemester(Guid semesterKey);
        Task<ICollection<Definition>> GetTypesAsync();
    }
}
