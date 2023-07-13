using AutoMapper;
using CityTransport.API.Models;
using CityTransport.Core.Data;

namespace CityTransport.API.Profiles
{
    public class BusWithScheduleProfile : Profile
    {
        public BusWithScheduleProfile()
        {
            CreateMap<Schedule, BusWithScheduleDTO>();
        }
    }
}
