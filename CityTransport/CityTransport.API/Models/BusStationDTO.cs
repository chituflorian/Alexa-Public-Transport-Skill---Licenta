using System.Text.Json.Serialization;

namespace CityTransport.API.Models
{
    public class BusStationDTO
    {
        [JsonIgnore]
        public int StationID { get; set; }
        public string StationName { get; set; }
    }
}
