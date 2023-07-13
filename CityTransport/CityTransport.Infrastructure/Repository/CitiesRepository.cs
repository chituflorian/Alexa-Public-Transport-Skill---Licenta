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
    public class CitiesRepository : ICitiesRepository
    {
        private readonly RatBVTransportContext _context;

        public CitiesRepository(RatBVTransportContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<City>> GetCitiesAsync()
        {
            var cities = await _context.Cities.Include(m => m.MetropolitanArea).ToListAsync();
            return cities;
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);

            return city;
        }
    }
}
