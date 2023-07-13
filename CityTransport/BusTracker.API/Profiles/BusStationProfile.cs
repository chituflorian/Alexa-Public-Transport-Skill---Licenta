using AutoMapper;
using BusTracker.API.Models;
using CityTransport.Core.Data;

namespace BusTracker.API.Profiles
{
    public class BusStationProfile : Profile
    {
        public BusStationProfile()
        {
            CreateMap<BusStation, BusStationDTO>();
        }

    }
}
