using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using CityTransport.Infrastructure.Data;

namespace CityTransport.Infrastructure.Repository
{
    public class AreasRepository : IAreasRepository
    {
        private readonly RatBVTransportContext _context;

        public AreasRepository(RatBVTransportContext context)
        {
            _context = context;
        }

        public Task<Area> GetAreaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Area>> GetAreasAsync()
        {
            throw new NotImplementedException();
        }
    }
}
