using AutoMapper;
using BusTracker.API.Models;
using CityTransport.Core.Data;

namespace BusTracker.API.Profiles
{
    public class MetropolitanAreaProfile : Profile
    {
        public MetropolitanAreaProfile()
        {
            CreateMap<MetropolitanArea, MetropolitanAreaDTO>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MetropolitanAreaName));
        }
    }
}
