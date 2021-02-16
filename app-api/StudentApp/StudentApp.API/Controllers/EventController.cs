using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentApp.Services.Contracts;
using RQ_POST = StudentApp.API.DataContracts.Requests.Event.POST;
using RQ_PUT = StudentApp.API.DataContracts.Requests.Event.PUT;
using DC = StudentApp.API.DataContracts;
using S = StudentApp.Services.Model;
using SR = StudentApp.Services.Responses.User;
using CustomAuth = StudentApp.Tools.Helpers;

namespace StudentApp.API.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IProjectService _projectService;
        private readonly ISemesterService _semesterService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IProjectService projectService, ISemesterService semesterService, IMapper mapper)
        {
            _eventService = eventService;
            _projectService = projectService;
            _semesterService = semesterService;
            _mapper = mapper;
        }

        #region GET SINGLE

        [CustomAuth.Authorize]
        [HttpGet("{eventKey}")]
        public async Task<DC.Event> GetSingle(Guid eventKey)
        {
            var data = await _eventService.GetSingleAsync(eventKey);

            return data != null ? _mapper.Map<DC.Event>(data) : null;
        }

        #endregion

        #region POST

        [CustomAuth.Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateEvent([FromBody] RQ_POST.EventPostRequest eventModel)
        {
            RQ_POST.EventPostValidator validator = new RQ_POST.EventPostValidator(_projectService);
            var results = await validator.ValidateAsync(eventModel.Event);

            if (results.IsValid)
            {
                var data = await _eventService.CreateAsync(_mapper.Map<S.Event>(eventModel));

                return data == 1 ? Ok() : Problem("Brak dostępu do bazy danych", null, 500);
            }

            return BadRequest(results.Errors);
        }

        #endregion

        #region PUT

        [HttpPut]
        public async Task<ActionResult> UpdateEvent([FromBody] RQ_PUT.EventPutRequest eventModel)
        {
            var userData = (SR.UserResponse) HttpContext.Items["User"];

            RQ_PUT.EventPutValidator validator = new RQ_PUT.EventPutValidator();
            var results = await validator.ValidateAsync(eventModel.Event);

            if (results.IsValid)
            {
                var data = await _eventService.UpdateAsync(_mapper.Map<S.Event>(eventModel));

                return data == 1 ? Ok() : Problem("Brak dostępu do db", null, 500);
            }

            return BadRequest(results.Errors);
        }

        #endregion

        #region GET ALL BY SUBJECT

        [CustomAuth.Authorize]
        [HttpGet("project/{subjectKey}")]
        public async Task<ICollection<DC.Event>> GetAllBySubject(Guid subjectKey)
        {
            var events = await _eventService.GetAllBySubjectAsync(subjectKey);
            return events != null ? _mapper.Map<ICollection<DC.Event>>(events) : null;
        }

        #endregion

        #region GET ALL BY DAY

        [CustomAuth.Authorize]
        [HttpGet("day/{days:int=90}")]
        public async Task<ICollection<DC.Event>> GetAllByDay(int days = 90)
        {
            var userData = (SR.UserResponse)HttpContext.Items["User"];

            if (userData == null)
                return null;

            var events = await _eventService.GetAllEventsInSemesterByDateAsync(userData.CurrentSemesterDefinitionKey, days);

            return events != null ? _mapper.Map<ICollection<DC.Event>>(events) : null;
        }

        #endregion
    }
}
