using System.Text.Json.Serialization;

namespace CityTransport.API.Models
{
    public class BusDTO
    {
        [JsonIgnore]
        public int BusID { get; set; }
        public string BusName { get; set; }
    }
}
