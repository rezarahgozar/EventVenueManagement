using AutoMapper;
using Infrastructure.Dto;
using Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<EventViewModel, EventDto>()
                .ForMember(dest => dest.Month, opt => opt.MapFrom(src => DateTime.Parse(src.StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind).Month.ToString()))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => DateTime.Parse(src.StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind).Year.ToString()))
                .ReverseMap();

            CreateMap<VenueViewModel, VenueDto>()
                .ReverseMap();
        }

    }
}
