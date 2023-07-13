using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Entities;
using CityTransport.Core.Interfaces;
using CityTransport.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CityTransport.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly RatBVTransportContext _context;

        public GenericRepository(RatBVTransportContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
