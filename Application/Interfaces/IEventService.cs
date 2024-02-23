using Infrastructure.Dto;
using Core.Models.InputModels;
using Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEventService
    {
        Task<List<EventDto>> GetEventListAsync(EventInputModel model);
        Task<EventDto> GetEventAsync(int eventId);
    }
}
