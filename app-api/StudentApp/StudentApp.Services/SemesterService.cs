using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using StudentApp.Tools.Configurations;

namespace StudentApp.Services
{
    public class SemesterService : ISemesterService 
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SemesterService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> GetSingleSemesterAsync(Guid semesterKey) => _context.Definition.SingleAsync(d => d.DefinitionKey == semesterKey).Result.DefinitionKey;

        public async Task<Definition> GetCurrentSemesterByDefinitionGroupAsync(Guid definitionGroupKey) =>
            await _context.Definition.SingleAsync(d =>
                d.DefinitionGroupKey == definitionGroupKey && d.Default == true);

        public async Task<Definition> GetCurrentSemesterByUserAsync(Guid userKey)
        {
            var query = from u in _context.User
                join dg in _context.DefinitionGroup on u.SemesterDefinitionGroupKey equals dg.DefinitionGroupKey
                join d in _context.Definition on dg.DefinitionGroupKey equals d.DefinitionGroupKey
                where u.UserKey == userKey && d.Default == true
                select d;

            return await query.SingleAsync();
        }

        public async Task<(Definition, ICollection<Definition>)> GetAllSemestersByUserAsync(Guid userKey)
        {
            var currentSemester = await GetCurrentSemesterByUserAsync(userKey);

            var query = from u in _context.User
                join dg in _context.DefinitionGroup on u.SemesterDefinitionGroupKey equals dg.DefinitionGroupKey
                join d in _context.Definition on dg.DefinitionGroupKey equals d.DefinitionGroupKey
                orderby d.Value
                where u.UserKey == userKey
                select d;

            return (currentSemester, await query.ToListAsync<Definition>());
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

            Guid newSemesterKey = Guid.NewGuid();
            DateTime currentDate = DateTime.Now;

            Definition definition = new Definition
            {
                DefinitionKey = newSemesterKey,
                DefinitionGroupKey = user.SemesterDefinitionGroupKey,
                GroupName = user.LoginName + "_SEMESTERS",
                Value = value,
                Default = false,
                CreateTime = currentDate,
                ModifyTime = currentDate
            };

            await _context.Definition.AddAsync(definition);
            await _context.SaveChangesAsync();

            await ChangeSemesterAsync(newSemesterKey);

            return definition.DefinitionKey;
        }
    }
}
