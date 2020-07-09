using System;
using System.Collections.Generic;
using EventManager.Services.Services;
using ManagerAPI.Models.DTOs.EM;
using ManagerAPI.Models.Models;
using ManagerAPI.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Backend.Controllers
{
    
    [Route ("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EventController : ControllerBase
    {
        private const string FATAL_ERROR = "Something bad happened. Try againg later";
        private readonly IEventService _eventService;
        private readonly ILoggerService _loggerService;

        public EventController(IEventService eventService, ILoggerService loggerService)
        {
            _eventService = eventService;
            _loggerService = loggerService;
        }

        [HttpGet("my")]
        public IActionResult GetMyEventsList()
        {
            try
            {
                return Ok(new ServerResponse<List<MyEventListDto>>(_eventService.GetMyEvents(), true));
            }
            catch (MessageException me) {
                return BadRequest (_loggerService.ExceptionToResponse (me));
            } 
            catch (Exception) {
                return BadRequest (_loggerService.ExceptionToResponse (new Exception(FATAL_ERROR)));
            }
        }

        [HttpGet("{eventId}")]
        public IActionResult GetEvent(int eventId)
        {
            try
            {
                return Ok(new ServerResponse<EventDto>(_eventService.GetEvent(eventId), true));
            }
            catch (MessageException me) {
                return BadRequest (_loggerService.ExceptionToResponse (me));
            } 
            catch (Exception) {
                return BadRequest (_loggerService.ExceptionToResponse (new Exception(FATAL_ERROR)));
            }
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] EventCreateDto model)
        {
            try
            {
                _eventService.CreateEvent(model);
                return Ok(new ServerResponse<Object>(null, true));
            }
            catch (MessageException me) {
                return BadRequest (_loggerService.ExceptionToResponse (me));
            } 
            catch (Exception) {
                return BadRequest (_loggerService.ExceptionToResponse (new Exception(FATAL_ERROR)));
            }
        }

        [HttpPost("gt/{eventId}")]
        public IActionResult SetEventAsGtEvent(int eventId)
        {
            try
            {
                _eventService.SetEventAsGtEvent(eventId);
                return Ok(new ServerResponse<Object>(null, true));
            }
            catch (MessageException me) {
                return BadRequest (_loggerService.ExceptionToResponse (me));
            } 
            catch (Exception) {
                return BadRequest (_loggerService.ExceptionToResponse (new Exception(FATAL_ERROR)));
            }
        }
        
        [HttpPost("sport/{eventId}")]
        public IActionResult SetEventAsSportEvent(int eventId)
        {
            try
            {
                _eventService.SetEventAsSportEvent(eventId);
                return Ok(new ServerResponse<Object>(null, true));
            }
            catch (MessageException me) {
                return BadRequest (_loggerService.ExceptionToResponse (me));
            } 
            catch (Exception) {
                return BadRequest (_loggerService.ExceptionToResponse (new Exception(FATAL_ERROR)));
            }
        }

        [HttpDelete("{eventId}")]
        public IActionResult DeleteEvent(int eventId)
        {
            try
            {
                _eventService.DeleteEvent(eventId);
                return Ok(new ServerResponse<Object>(null, true));
            }
            catch (MessageException me) {
                return BadRequest (_loggerService.ExceptionToResponse (me));
            } 
            catch (Exception) {
                return BadRequest (_loggerService.ExceptionToResponse (new Exception(FATAL_ERROR)));
            }
        }

        [HttpPut("{eventId}")]
        public IActionResult UpdateMaterEvent(int eventId, [FromBody] MasterEventUpdateDto masterUpdate)
        {
            try
            {
                _eventService.UpdateMasterEvent(masterUpdate);
                return Ok(new ServerResponse<Object>(null, true));
            }
            catch (MessageException me) {
                return BadRequest (_loggerService.ExceptionToResponse (me));
            } 
            catch (Exception) {
                return BadRequest (_loggerService.ExceptionToResponse (new Exception(FATAL_ERROR)));
            }
        }
        
        [HttpPut("sport/{sportEventId}")]
        public IActionResult UpdateSportEvent(int sportEventId, [FromBody] SportEventUpdateDto sportUpdate)
        {
            try
            {
                _eventService.UpdateSportEvent(sportUpdate);
                return Ok(new ServerResponse<Object>(null, true));
            }
            catch (MessageException me) {
                return BadRequest (_loggerService.ExceptionToResponse (me));
            } 
            catch (Exception) {
                return BadRequest (_loggerService.ExceptionToResponse (new Exception(FATAL_ERROR)));
            }
        }
        
        [HttpPut("gt/{gtEventId}")]
        public IActionResult UpdateGtEvent(int gtEventId, [FromBody] GtEventUpdateDto updateGt)
        {
            try
            {
                _eventService.UpdateGtEvent(updateGt);
                return Ok(new ServerResponse<Object>(null, true));
            }
            catch (MessageException me) {
                return BadRequest (_loggerService.ExceptionToResponse (me));
            } 
            catch (Exception) {
                return BadRequest (_loggerService.ExceptionToResponse (new Exception(FATAL_ERROR)));
            }
        }
    }
}