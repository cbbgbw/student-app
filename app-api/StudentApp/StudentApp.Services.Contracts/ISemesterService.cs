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
        Task<Guid> GetSingleSemesterAsync(Guid semesterKey);
        Task<Definition> GetCurrentSemesterByDefinitionGroupAsync(Guid definitionGroupKey);
        Task<Definition> GetCurrentSemesterByUserAsync(Guid userKey);
        Task<(Definition,ICollection<Definition>)> GetAllSemestersByUserAsync(Guid userKey);
        Task<int> ChangeSemesterAsync(Guid semesterKey);
        Task<Guid> CreateSemesterAsync(Guid userKey, string value);
    }
}
