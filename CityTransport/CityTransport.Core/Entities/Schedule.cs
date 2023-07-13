using System;
using System.Collections.Generic;
using CityTransport.Core.Entities;

namespace CityTransport.Core.Data
{
    public partial class Schedule : Entity
    {
        public int ScheduleId { get; set; }
        public int? BusId { get; set; }
        public int? StationId { get; set; }
        public string ArrivalTime { get; set; }
        public TimeSpan? ArrivalTimeExplicit { get; set; }
        public string DayOfWeek { get; set; }

        public virtual Bus Bus { get; set; }
        public virtual BusStation Station { get; set; }
    }
}
