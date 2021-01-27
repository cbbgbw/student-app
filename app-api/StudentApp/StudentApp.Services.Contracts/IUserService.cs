using System;
using System.Collections.Generic;
using StudentApp.Services.Model;
using System.Threading.Tasks;

namespace StudentApp.Services.Contracts
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string loginName, string password);
        Task<int> CreateAsync(User user, string password);
        Task<User> GetSingleAsync(Guid userKey);
        Task<ICollection<User>> GetAllAsync();
    }
}
