using AutoMapper;
using BusTracker.API.Models;
using CityTransport.Core.Data;

namespace BusTracker.API.Profiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleDTO>();
        }
    }
}
