using Application.Interfaces;
using Core.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using Application.Common;
using System.Reflection;
using AutoMapper;
using Infrastructure.Dto;
using System.Net.Http;

namespace Application.Services
{
    public class FetchDataService : IFetchDataService
    {
        private readonly IConfiguration _confiquration;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public FetchDataService(IConfiguration confiquration, IMemoryCache memoryCache, IMapper mapper)
        {
            _confiquration = confiquration;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        public async Task<EventVenueDto> GetVenueEventAsync()

        {

            var eventVenueList = await _memoryCache.GetOrCreateAsync(CacheKeyList.VenueListKey, async entry =>
            {
                // Set cache entry options
                entry.SetSlidingExpiration(TimeSpan.FromMinutes(10));
                entry.Priority = CacheItemPriority.Normal;

                var eventVenueList = await GetVenueEventFromApiAsync();

                return eventVenueList;
            });

            if(eventVenueList == null)
                _memoryCache.Remove(CacheKeyList.VenueListKey);

            return eventVenueList;

        }

        private async Task<EventVenueDto> GetVenueEventFromApiAsync()
        {
            var url = _confiquration.GetSection("Settings").GetSection("APIUrl").Value;

            using (var httpClient = new HttpClient())
            {
                // validate event source
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                String urlContents = await response.Content.ReadAsStringAsync();

                var json = await httpClient.GetStringAsync(url);
                var eventVenueList = JsonConvert.DeserializeObject<EventVenueViewModel>(json);
                var eventVenueListDto = new EventVenueDto();
                eventVenueListDto.Venues = _mapper.Map<List<VenueDto>>(eventVenueList?.Venues);
                eventVenueListDto.Events = _mapper.Map<List<EventDto>>(eventVenueList?.Events);

                return eventVenueListDto;

            }
        }
    }
}
