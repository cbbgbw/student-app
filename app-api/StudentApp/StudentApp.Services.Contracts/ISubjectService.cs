using StudentApp.Services.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApp.Services.Contracts
{
    public interface ISubjectService
    {
        Task<Subject> GetSingleAsync(Guid subjectKey);
        Task<int> CreateAsync(Subject subject);
        Task<bool> UpdateAsync(Subject subject);
        Task<bool> DeleteAsync(Guid subjectKey);
        Task<ICollection<Subject>> GetAllBySemesterAsync(Guid semesterKey);
        Task<ICollection<Definition>> GetTypes();
    }
}
