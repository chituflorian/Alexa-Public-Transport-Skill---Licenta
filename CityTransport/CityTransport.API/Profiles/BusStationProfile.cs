using AutoMapper;
using CityTransport.API.Models;
using CityTransport.Core.Data;

namespace CityTransport.API.Profiles
{
    public class BusStationProfile : Profile
    {
        public BusStationProfile()
        {
            CreateMap<BusStation, BusStationDTO>();
        }

    }
}
