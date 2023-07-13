using System.Text.Json.Serialization;

namespace BusTracker.API.Models
{
    public class ScheduleDTO
    {
        public string ArrivalTime { get; set; }
        public string DayOfWeek { get; set; }
    }
}
