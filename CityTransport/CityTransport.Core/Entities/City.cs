using System;
using System.Collections.Generic;
using CityTransport.Core.Entities;

namespace CityTransport.Core.Data
{
    public partial class City : Entity
    {
        public City()
        {
            Areas = new HashSet<Area>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int MetropolitanAreaId { get; set; }

        public virtual MetropolitanArea MetropolitanArea { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
    }
}
