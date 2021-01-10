using AutoMapper;
using Microsoft.Extensions.Options;
using StudentApp.API.Common.Settings;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using StudentApp.Tools.Configurations;

namespace StudentApp.Services
{
    public class UserService : IUserService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IOptions<AppSettings> settings, IMapper mapper, DataContext context)
        {
            _settings = settings?.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<User> GetSingleAsync(Guid userKey)
        {
            return await _context.User.SingleAsync(user => user.UserKey == userKey);
        }

        public async Task<int> CreateAsync(User user)
        {
            await _context.User.AddAsync(user);
            return await _context.SaveChangesAsync();
        }


    }
}
