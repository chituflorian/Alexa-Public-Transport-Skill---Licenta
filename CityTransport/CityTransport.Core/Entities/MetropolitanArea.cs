using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CityTransport.Core.Entities;

namespace CityTransport.Core.Data
{
    public partial class MetropolitanArea : Entity
    {
        public MetropolitanArea()
        {
            Cities = new HashSet<City>();
        }

        public int MetropolitanAreaId { get; set; }
        public string MetropolitanAreaName { get; set; }
       
        public virtual ICollection<City> Cities { get; set; }
    }
}
