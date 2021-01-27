using AutoMapper;
using Microsoft.Extensions.Options;
using StudentApp.API.Common.Settings;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentApp.Tools.Configurations;
using StudentApp.Tools.Helpers;

namespace StudentApp.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IOptions<AppSettings> settings, IMapper mapper, DataContext context)
        {
            _settings = settings?.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<User> AuthenticateAsync(string loginName, string password)
        {
            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(password))
                return null;
            
            var user = await _context.User.SingleOrDefaultAsync(u =>
                u.LoginName == loginName);

            if (user == null)
                return null;

            return PasswordHash.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) == false ? null : user;
        }

        public async Task<User> GetSingleAsync(Guid userKey)
        {
            return await _context.User.SingleAsync(user => user.UserKey == userKey);
        }

        public async Task<ICollection<User>> GetAllAsync() => await  _context.User.ToListAsync();

        public async Task<int> CreateAsync(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Wymagane podanie has³a");

            if (await _context.User.AnyAsync(u => u.LoginName == user.LoginName))
                throw new AppException("U¿ytkownik \"" + user.LoginName + "\" ju¿ istnieje");

            byte[] passwordHash, passwordSalt;
            PasswordHash.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            /* Creating new semester group */
            DateTime date = DateTime.Now;
            Guid newDefinitionGroup = Guid.NewGuid();
            
            DefinitionGroup semesterGroup = new DefinitionGroup
            {
                DefinitionGroupKey = newDefinitionGroup,
                Description = "Semestr u¿ytkownika " + user.LoginName,
                GroupName = user.LoginName + "_SEMESTERS",
                CreateTime = date,
                ModifyTime = date
            };

            await _context.DefinitionGroup.AddAsync(semesterGroup);
            await _context.SaveChangesAsync();

            user.SemesterDefinitionGroupKey = newDefinitionGroup;

            await _context.User.AddAsync(user);
            return await _context.SaveChangesAsync();
        }

    }
}
