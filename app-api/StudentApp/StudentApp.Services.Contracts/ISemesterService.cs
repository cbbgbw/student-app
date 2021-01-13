using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Services.Model;

namespace StudentApp.Services.Contracts
{
    public interface ISemesterService
    {
        Task<Guid> GetSingleSemester(Guid semesterKey);
        Task<ICollection<Definition>> GetAllSemestersByUser(Guid userKey);
        Task<int> ChangeSemester(Guid semesterKey);
        Task<Guid> CreateSemester(Guid userKey, string value);
    }
}
