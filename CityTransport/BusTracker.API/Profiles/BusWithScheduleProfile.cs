using AutoMapper;
using BusTracker.API.Models;
using CityTransport.Core.Data;

namespace BusTracker.API.Profiles
{
    public class BusWithScheduleProfile : Profile
    {
        public BusWithScheduleProfile()
        {
            CreateMap<Schedule, BusWithScheduleDTO>();
        }
    }
}
