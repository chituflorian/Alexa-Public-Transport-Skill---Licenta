using System;
using System.Collections.Generic;
using CityTransport.Core.Entities;

namespace CityTransport.Core.Data
{
    public partial class Area : Entity 
    {
        public Area()
        {
            BusStations = new HashSet<BusStation>();
        }
        
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<BusStation> BusStations { get; set; }
    }
}
