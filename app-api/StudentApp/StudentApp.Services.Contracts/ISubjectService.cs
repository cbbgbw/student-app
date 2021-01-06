using StudentApp.Services.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApp.Services.Contracts
{
    public interface ISubjectService
    {
        Task<int> CreateAsync(Subject subject);
        Task<bool> UpdateAsync(Subject subject);
        Task<bool> DeleteAsync(Guid subjectKey);
        Task<Subject> GetSingleAsync(Guid subjectKey);
        Task<ICollection<Subject>> GetAllBySemesterAsync(int semester);
        Task<ICollection<Definition>> GetTypes();
    }
}
