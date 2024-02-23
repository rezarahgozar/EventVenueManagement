using Infrastructure.Dto;
using Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFetchDataService
    {
        Task<EventVenueDto> GetVenueEventAsync();
    }
}
