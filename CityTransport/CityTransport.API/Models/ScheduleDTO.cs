using System.Text.Json.Serialization;

namespace CityTransport.API.Models
{
    public class ScheduleDTO
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonIgnore]
        public int StationID { get; set; }
        public BusStationDTO Station { get; set; }
        public string ArrivalTime { get; set; }
        public string DayOfWeek { get; set; }
    }
}
