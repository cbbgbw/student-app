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
        Task<Event> CreateAsync(Guid eventKey);
    }
}
