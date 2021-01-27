using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentApp.API.Common.Settings;
using StudentApp.Services.Contracts;
using StudentApp.Services.Model;
using StudentApp.Tools.Configurations;

namespace StudentApp.Services
{
    public class EventService : IEventService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public EventService(IOptions<AppSettings> settings, IMapper mapper, DataContext context)
        {
            _settings = settings?.Value;
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<Event> GetSingleAsync(Guid eventKey) => await _context.Event.SingleAsync(ev => ev.EventKey == eventKey);
        

        public async Task<int> CreateAsync(Event eventModel)
        {
            await _context.Event.AddAsync(eventModel);
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Event>> GetAllBySubject(Guid subjectKey)
        {
            var query = from s in _context.Subject
                join p in _context.Project on s.SubjectKey equals p.SubjectKey
                join ev in _context.Event on p.ProjectKey equals ev.ProjectKey
                where s.SubjectKey == subjectKey
                select ev;

            return query.ToList<Event>();
        }
    }
}
