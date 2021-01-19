using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Services.Contracts;
using RQ = StudentApp.API.DataContracts.Requests.Event.POST;
using DC = StudentApp.API.DataContracts;
using S = StudentApp.Services.Model;

namespace StudentApp.API.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IProjectService projectService, IMapper mapper)
        {
            _eventService = eventService;
            _projectService = projectService;
            _mapper = mapper;
        }

        #region GET SINGLE

        [HttpGet("{eventKey}")]
        public async Task<DC.Event> GetSingle(Guid eventKey)
        {
            var data = await _eventService.GetSingleAsync(eventKey);

            return data != null ? _mapper.Map<DC.Event>(data) : null;
        }

        #endregion

        #region POST
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromBody] RQ.EventPostRequest eventModel)
        {
            RQ.EventPostValidator validator = new RQ.EventPostValidator(_projectService);
            var results = await validator.ValidateAsync(eventModel.Event);

            if (results.IsValid)
            {
                var data = await _eventService.CreateAsync(_mapper.Map<S.Event>(eventModel));

                return data == 1 ? Ok() : Problem("Brak dostępu do bazy danych", null, 500);
            }

            return BadRequest(results.Errors);
        }

        #endregion

        #region GET ALL BY SUBJECT

        [HttpGet("project/{subjectKey}")]
        public async Task<ICollection<DC.Event>> GetAllBySubject(Guid subjectKey)
        {
            var events = _eventService.GetAllBySubject(subjectKey).Result;
            return events != null ? _mapper.Map<ICollection<DC.Event>>(events) : null;
        }

        #endregion
    }
}
