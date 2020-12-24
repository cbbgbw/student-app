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

        public async Task<Subject> CreateAsync(Subject subject)
        {
            if (string.IsNullOrEmpty(subject.Name))
                throw new AppException("Subject Name is required.");
            
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            
            return subject;
        }

        public async Task<bool> UpdateAsync(Subject subject)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid SubjectKEY)
        {
            throw new NotImplementedException();
        }

        public async Task<Subject> GetAsync(Guid SubjectKEY)
        {
            return _context.Subjects.SingleAsync(subject => subject.SubjectKey == SubjectKEY).Result;

            // Temp def of Subject without db
            //return new Subject
            //{
            //    SubjectKEY = SubjectKEY,
            //    Name = "",
            //    Description = "",
            //    CurrentSubjectStateKEY = Guid.NewGuid(),
            //    HasProjectToPass = false,
            //    Semester = 1,
            //    CreateTime = DateTime.Now,
            //    ModifyTime = DateTime.Now,
            //    isArchive = false
            //};
        }
    }
}
