using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CityTransport.Core.Entities;

namespace CityTransport.Core.Data
{
    public partial class BusStation : Entity
    {
        public BusStation()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int StationId { get; set; }
        public string StationName { get; set; }
        public int? AreaId { get; set; }

        public virtual Area Area { get; set; }
       
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
