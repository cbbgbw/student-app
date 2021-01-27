using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentApp.API.Common.Settings;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using StudentApp.Tools.Configurations;

namespace StudentApp.Services
{
    public class SemesterService : ISemesterService 
    {
        private readonly DataContext _context;
        private AppSettings _appSettings;
        private readonly IMapper _mapper;

        public SemesterService(DataContext context, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _context = context;
            _appSettings = appSettings?.Value;
            _mapper = mapper;
        }

        public async Task<Guid> GetSingleSemesterAsync(Guid semesterKey) => _context.Definition.SingleAsync(d => d.DefinitionKey == semesterKey).Result.DefinitionKey;

        public async Task<Definition> GetCurrentSemesterByDefinitionGroupAsync(Guid definitionGroupKey) =>
            await _context.Definition.SingleAsync(d =>
                d.DefinitionGroupKey == definitionGroupKey && d.Default == true);

        public async Task<ICollection<Definition>> GetAllSemestersByUserAsync(Guid userKey)
        {
            var query = from u in _context.User
                join dg in _context.DefinitionGroup on u.SemesterDefinitionGroupKey equals dg.DefinitionGroupKey
                join d in _context.Definition on dg.DefinitionGroupKey equals d.DefinitionGroupKey
                orderby d.Default descending 
                where u.UserKey == userKey
                select d;

            return await query.ToListAsync<Definition>();
        }

        public async Task<int> ChangeSemesterAsync(Guid semesterKey)
        {
            var semester = await _context.Definition.FindAsync(semesterKey);

            if (semester == null)
                throw new AppException("Nie znaleziono podanego semestru");

            //Change default of last semester definition to false (should be one)
            var lastSemesterWithDefault = await _context.Definition.FirstOrDefaultAsync(d => d.DefinitionGroupKey == semester.DefinitionGroupKey && d.Default == true);

            if (lastSemesterWithDefault != null) lastSemesterWithDefault.Default = false;

            semester.Default = true;

            return await _context.SaveChangesAsync();
        }

        public async Task<Guid> CreateSemesterAsync(Guid userKey, string value)
        {
            var user = _context.User.FindAsync(userKey).Result;

            //If user has no semesters, give default as 1
            bool defaultValue = GetAllSemestersByUserAsync(userKey).Result == null ? true : false;
            DateTime currentDate = DateTime.Now;

            Definition definition = new Definition
            {
                DefinitionKey = Guid.NewGuid(),
                DefinitionGroupKey = user.SemesterDefinitionGroupKey,
                GroupName = user.LoginName + "_SEMESTERS",
                Value = value,
                Default = defaultValue,
                CreateTime = currentDate,
                ModifyTime = currentDate
            };

            await _context.Definition.AddAsync(definition);
            await _context.SaveChangesAsync();

            return definition.DefinitionKey;
        }
    }
}
