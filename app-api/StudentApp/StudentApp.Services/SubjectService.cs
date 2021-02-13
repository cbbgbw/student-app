using AutoMapper;
using Microsoft.Extensions.Options;
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
using StudentApp.Services.Responses.Subject;
using StudentApp.Tools.Configurations;
using R = StudentApp.Services.Responses.Subject;

namespace StudentApp.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SubjectService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> CreateAsync(Subject subject)
        {
            await _context.Subject.AddAsync(subject);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Subject subject)
        {
            //_context.Subject.Update(subject)
            var modifyingSubject = await _context.Subject.FirstOrDefaultAsync(s => s.SubjectKey == subject.SubjectKey);

            modifyingSubject.Name = subject.Name;
            modifyingSubject.Description = subject.Description;
            modifyingSubject.IsPassed = subject.IsPassed;
            modifyingSubject.TypeDefinitionKey = subject.TypeDefinitionKey;
            modifyingSubject.HasProjectToPass = subject.HasProjectToPass;
            modifyingSubject.SemesterDefinitionKey = subject.SemesterDefinitionKey;
            modifyingSubject.ModifyTime = subject.ModifyTime;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid subjectKey)
        {
            throw new NotImplementedException();
        }

        public async Task<R.SubjectResponse> GetSingleAsync(Guid subjectKey)
        {
            var subject = await _context.Subject.SingleAsync(subject => subject.SubjectKey == subjectKey);
            var query = from s in _context.Subject
                join d in _context.Definition on s.TypeDefinitionKey equals d.DefinitionKey
                where s.SubjectKey == subject.SubjectKey
                select d.Value;

            var typeDefinitionName = await query.SingleOrDefaultAsync();

            return new SubjectResponse(subject, typeDefinitionName);
        }

        public async Task<ICollection<R.SubjectResponse>> GetAllBySemesterAsync(Guid semesterKey)
        {
            var query = from s in _context.Subject
                        join d in _context.Definition on s.TypeDefinitionKey equals d.DefinitionKey
                        where s.SemesterDefinitionKey == semesterKey
                        select new
                        {
                            d.Value,
                            s
                        };

            var subjects = new List<SubjectResponse>();

            var data = await query.ToListAsync();

            foreach (var item in data)
            {
                subjects.Add(new SubjectResponse(item.s, item.Value));
            }

            return subjects;
        }

        public async Task<int> GetSubjectCountBySemester(Guid semesterKey)
        {
            var subjects = await GetAllBySemesterAsync(semesterKey);

            return subjects?.Count ?? 0;
        }

        public async Task<ICollection<Definition>> GetTypesAsync()
        {
            var retVal = await _context.DefinitionGroup
                .Include(dg => dg.Definitions)
                .AsSplitQuery()
                .SingleAsync(group => Equals(group.GroupName, "SUBJECT_TYPES"));

            return retVal.Definitions;
        }
    }

}
