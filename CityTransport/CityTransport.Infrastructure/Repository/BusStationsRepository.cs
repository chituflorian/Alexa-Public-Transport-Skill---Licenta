using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using CityTransport.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CityTransport.Infrastructure.Repository
{
    public class BusStationsRepository : IBusStationsRepository
    {
        private readonly RatBVTransportContext _context;

        public BusStationsRepository(RatBVTransportContext context)
        {
            _context = context;
        }

        public Task<BusStation> GetBusStationById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<BusStation>> GetBusStations()
        {
            throw new NotImplementedException();
        }

    }
}
