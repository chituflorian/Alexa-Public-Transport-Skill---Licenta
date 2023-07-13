using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;
using CityTransport.Core.Entities;

namespace CityTransport.Core.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
