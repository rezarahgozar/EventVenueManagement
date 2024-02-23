using Application.Interfaces;
using Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Core.Models.InputModels;
using Microsoft.Extensions.Options;
using Infrastructure.Dto;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private readonly IFetchDataService _fetchDataService;

        public EventService(IFetchDataService fetchDataService)
        {
            _fetchDataService = fetchDataService;
        }

        public async Task<EventDto> GetEventAsync(int eventId)
        {
            var result = await _fetchDataService.GetVenueEventAsync();
            if (result != null)
                return result.Events.Find(q => q.Id == eventId);
            else
                return null;
        }

        public async Task<List<EventDto>> GetEventListAsync(EventInputModel model)
        {
            DateTime startDate = DateTime.Parse(model.SelectedDate, null, System.Globalization.DateTimeStyles.RoundtripKind);

            var result = await _fetchDataService.GetVenueEventAsync();
            if (result!= null) {
            var eventList = result?.Events?
                .Where(q => q.VenueId == model.VenueId )
                .Where(q => q.Year == startDate.Year.ToString())
                .Where(q => q.Month == startDate.Month.ToString())
                .ToList();
            return eventList;
            }
            else
                return null;
        }
    }
}
