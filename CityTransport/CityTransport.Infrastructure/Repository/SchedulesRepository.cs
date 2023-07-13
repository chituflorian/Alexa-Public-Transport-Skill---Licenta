using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;
using CityTransport.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CityTransport.Infrastructure.Repository
{
    public class SchedulesRepository
    {
        private readonly RatBVTransportContext _context;

        public SchedulesRepository(RatBVTransportContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Bus>> GetBusesByStationName(string stationName)
        {
            var station = await _context.BusStations.FirstOrDefaultAsync(s => s.StationName == stationName);

            if (station == null)
            {
                return null;
            }

            var buses = await _context.Schedules
                .Include(s => s.Bus)
                .Where(s => s.StationId == station.StationId)
                .Select(s => s.Bus)
                .Distinct()
                .ToListAsync();

            return buses;
        }
    }
}
