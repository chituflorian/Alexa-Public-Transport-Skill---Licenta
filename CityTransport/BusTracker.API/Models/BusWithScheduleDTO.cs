using System.Text.Json.Serialization;
using CityTransport.Core.Data;

namespace BusTracker.API.Models
{
    public class BusWithScheduleDTO
    {
        public string BusName { get; set; }
        public ICollection<BusScheduleDTO> Schedules { get; set; }
    }
}
