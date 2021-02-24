using System;
using System.Collections.Generic;
using StudentApp.Services.Model;
using System.Threading.Tasks;
using StudentApp.Services.Responses.User;

namespace StudentApp.Services.Contracts
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string loginName, string password);
        Task<int> CreateAsync(User user, string password, int semesterValue);
        Task<User> GetSingleAsync(Guid userKey);
        Task<User> GetSingleByLoginAsync(string loginName);
        Task<UserResponse> GetSingleWithCurrentSemesterAsync(Guid userKey);
        Task<ICollection<User>> GetAllAsync();
        Task<int> UpdatePassword(string loginName, string oldPassword, string newPassword);
    }
}
