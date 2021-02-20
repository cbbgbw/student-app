using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Services.Model;

namespace StudentApp.Services.Contracts
{
    public interface IEventService
    {
        Task<Event> GetSingleAsync(Guid eventKey);
        Task<int> CreateAsync(Event eventModel);
        Task<int> UpdateAsync(Event eventModel);
        Task<ICollection<Event>> GetAllByProjectAsync(Guid projectKey);
        Task<ICollection<Event>> GetAllBySubjectAsync(Guid subjectKey);
        Task<ICollection<Event>> GetAllEventsInSemesterByDateAsync(Guid semesterKey, int days);
        Task<ICollection<Event>> GetAllInCurrentMonth(int year, int month, Guid semesterKey);
    }
}
