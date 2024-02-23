using Application.Interfaces;
using AutoMapper;
using Core.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class EventVenueController : ControllerBase
    {
        private readonly IFetchDataService _fetchDataService;
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventVenueController(IFetchDataService fetchDataService, IEventService eventService, IMapper mapper)
        {
            _fetchDataService = fetchDataService;
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventVenueListAsync()
        {
            var result = await _fetchDataService.GetVenueEventAsync();
            if (result != null)
                return Ok(result);
            else
                return NotFound("Please check your resource");
        }

        [HttpGet]
        public async Task<IActionResult> GetVenueListAsync()
        {
            var result = await _fetchDataService.GetVenueEventAsync();
            if (result != null)
            {
                var venueList = result != null ? result.Venues : null;
                return Ok(venueList);
            }    
            else
                return NotFound("Please check your resource");
 
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventAsync(int eventId)
        {
            var result = await _eventService.GetEventAsync(eventId);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Could not find any event. Please check your resource");
        }

        [HttpPost]
        public async Task<IActionResult> GetEventListAsync([FromBody] EventInputModel model)
        {
            var result = await _eventService.GetEventListAsync(model);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Please check your resource");

        }
    }
}
