using AutoMapper;
using CityTransport.API.Models;
using CityTransport.Core.Data;

namespace CityTransport.API.Profiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleDTO>();
        }
    }
}
