using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Services.Model;

namespace StudentApp.Services.Contracts
{
    public interface IProjectService
    {
        Task<Project> CreateAsync(Project project);
        Task<Project> GetSingleAsync(Guid projectKey);
    }
}
