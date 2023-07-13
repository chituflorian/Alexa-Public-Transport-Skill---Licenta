using System.Text.Json.Serialization;
using CityTransport.Core.Data;

namespace CityTransport.API.Models
{
    public class BusWithScheduleDTO
    {
        [JsonIgnore]
        public int ScheduleId { get; set; }
        [JsonIgnore]
        public int? BusId { get; set; }
        [JsonIgnore]
        public int? StationId { get; set; }
        public BusDTO Bus { get; set; }
        public string ArrivalTime { get; set; }
        public string DayOfWeek { get; set; }
        public BusStationDTO Station { get; set; }
    }
}
