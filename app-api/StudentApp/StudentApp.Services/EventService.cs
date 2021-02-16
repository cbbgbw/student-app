using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using StudentApp.Tools.Configurations;

namespace StudentApp.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public EventService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<Event> GetSingleAsync(Guid eventKey) => await _context.Event.SingleAsync(ev => ev.EventKey == eventKey);
        

        public async Task<int> CreateAsync(Event eventModel)
        {
            await _context.Event.AddAsync(eventModel);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Event eventModel)
        {
            var modifyingEvent = await _context.Event.FirstOrDefaultAsync(e => e.EventKey == eventModel.EventKey);

            modifyingEvent.Title = eventModel.Title;
            modifyingEvent.Content = eventModel.Content;
            modifyingEvent.SetTime = eventModel.SetTime;
            modifyingEvent.ModifyTime = eventModel.ModifyTime;

            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Event>> GetAllBySubjectAsync(Guid subjectKey)
        {
            var query = from s in _context.Subject
                join p in _context.Project on s.SubjectKey equals p.SubjectKey
                join ev in _context.Event on p.ProjectKey equals ev.ProjectKey
                where s.SubjectKey == subjectKey
                select ev;

            return await query.ToListAsync<Event>();
        }

        public async Task<ICollection<Event>> GetAllEventsInSemesterByDateAsync(Guid semesterKey, int days)
        {
            var toDate = DateTime.Now.AddDays(days);

            var query = from s in _context.Subject
                join p in _context.Project on s.SubjectKey equals p.SubjectKey
                join e in _context.Event on p.ProjectKey equals e.ProjectKey 
                orderby e.SetTime ascending
                where s.SemesterDefinitionKey == semesterKey
                      && e.SetTime < toDate
                select e;

            return await query.ToListAsync();
        }
    }
}
