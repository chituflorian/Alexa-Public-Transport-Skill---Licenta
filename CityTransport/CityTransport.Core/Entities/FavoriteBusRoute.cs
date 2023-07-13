using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;
using CityTransport.Core.Entities;

namespace CityTransport.Core.Data
{
    public class FavoriteBusRoute : Entity
    {
        [Key]
        public int RouteId { get; set; }
        public string BusName { get; set; }
        public string StationFrom { get; set; }
        public string StationTo { get; set; }

    }
}
