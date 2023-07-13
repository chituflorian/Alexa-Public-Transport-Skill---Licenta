using AutoMapper;
using BusTracker.API.Models;
using CityTransport.Core.Data;

namespace BusTracker.API.Profiles
{
    public class BusProfile : Profile
    {
        public BusProfile()
        {
            CreateMap<Bus, BusDTO>();
            /** in the BusProfile class, we define a mapping from the Bus entity to the BusWithScheduleDTO DTO.
            To include the schedules for the bus, we first use the ForMember method to map the BusName property of the Bus entity to the BusName
            property of the DTO.Then, we use the MapFrom method to map the Schedules property of the Bus entity to a list of 
            BusScheduleDTO objects. For each Schedule in the Schedules property of the Bus entity, we create a new BusScheduleDTO object and map
            the ArrivalTime and DayOfWeek properties of the Schedule entity to the corresponding properties of the BusScheduleDTO object.
             */
            CreateMap<Bus, BusWithScheduleDTO>()
                .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules.Select(s => new BusScheduleDTO
                {
                    ArrivalTime = s.ArrivalTime,
                    DayOfWeek = s.DayOfWeek
                })));
            //CreateMap<Bus, BusWithScheduleDTO>()
            //.ForMember(dest => dest.BusName, opt => opt.MapFrom(src => src.BusName))
            //.ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(src => src.Schedules.FirstOrDefault().ArrivalTime))
            //.ForMember(dest => dest.DayOfWeek, opt => opt.MapFrom(src => src.Schedules.FirstOrDefault().DayOfWeek));

        }
    }
}
