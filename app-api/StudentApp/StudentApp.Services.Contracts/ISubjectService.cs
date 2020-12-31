using StudentApp.Services.Model;
using System;
using System.Threading.Tasks;

namespace StudentApp.Services.Contracts
{
    public interface ISubjectService
    {
        Task<Subject> CreateAsync(Subject subject);
        Task<bool> UpdateAsync(Subject subject);
        Task<bool> DeleteAsync(Guid subjectKey);
        Task<Subject> GetSingleAsync(Guid subjectKey);
    }
}
