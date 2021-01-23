using AutoMapper;
using Microsoft.Extensions.Options;
using StudentApp.API.Common.Settings;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentApp.Tools.Configurations;

namespace StudentApp.Services
{
    public class SubjectService : ISubjectService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SubjectService(IOptions<AppSettings> settings, IMapper mapper, DataContext context)
        {
            _settings = settings?.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> CreateAsync(Subject subject)
        {
            await _context.Subject.AddAsync(subject);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Subject subject)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid subjectKey)
        {
            throw new NotImplementedException();
        }

        public async Task<Subject> GetSingleAsync(Guid subjectKey)
        {
            return _context.Subject.SingleAsync(subject => subject.SubjectKey == subjectKey).Result;
        }

        public async Task<ICollection<Subject>> GetAllBySemesterAsync(Guid semesterKey)
        {
            return _context.Subject.Where(sub => sub.SemesterDefinitionKey == semesterKey).ToList();
        }

        public async Task<ICollection<Definition>> GetTypes()
        {
            var retVal = await _context.DefinitionGroup
                .Include(dg => dg.Definitions)
                .AsSplitQuery()
                .SingleAsync(group => Equals(group.GroupName, "SUBJECT_TYPES"));

            return retVal.Definitions;
        }
    }
}
