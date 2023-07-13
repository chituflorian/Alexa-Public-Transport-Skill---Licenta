using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using CityTransport.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CityTransport.Infrastructure.Repository
{
    public class MetropolitanAreasRepository : IMetropolitanAreasRepository
    {
        private readonly RatBVTransportContext _context;

        public MetropolitanAreasRepository(RatBVTransportContext context)
        {
            _context = context;
        }

        public Task<MetropolitanArea> GetMetropolitanAreaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<MetropolitanArea>> GetMetropolitanAreasAsync()
        {
            return await _context.MetropolitanAreas.ToListAsync(); 
        }
    }
}
