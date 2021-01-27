using System;
using StudentApp.Services.Model;
using System.Threading.Tasks;

namespace StudentApp.Services.Contracts
{
    public interface IUserService
    {
        Task<int> CreateAsync(User user);
        Task<User> GetSingleAsync(Guid userKey);
    }
}
