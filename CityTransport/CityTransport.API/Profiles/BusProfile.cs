using AutoMapper;
using CityTransport.API.Models;
using CityTransport.Core.Data;

namespace CityTransport.API.Profiles
{
    public class BusProfile : Profile
    {
        public BusProfile()
        {
            CreateMap<Bus, BusDTO>();
        }
    }
}
