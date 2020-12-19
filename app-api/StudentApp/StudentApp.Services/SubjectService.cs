using AutoMapper;
using Microsoft.Extensions.Options;
using StudentApp.API.Common.Settings;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services
{
    class SubjectService : ISubjectService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;

        public SubjectService(IOptions<AppSettings> settings, IMapper mapper)
        {
            _settings = settings?.Value;
            _mapper = mapper;
        }

        public async Task<Subject> CreateAsync(Subject subject)
        {
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
            // Temp def of Subject without db
            return new Subject
            {
                SubjectKEY = SubjectKEY,
                Name = "",
                Description = "",
                CurrentSubjectStateKEY = Guid.NewGuid(),
                HasProjectToPass = false,
                Semester = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now,
                isArchive = false
            };
        }
    }
}
