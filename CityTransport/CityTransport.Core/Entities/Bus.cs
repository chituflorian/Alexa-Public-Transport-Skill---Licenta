using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CityTransport.Core.Entities;

namespace CityTransport.Core.Data
{
    public partial class Bus : Entity
    {
        public Bus()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int BusId { get; set; }
        public string BusName { get; set; }
  
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
