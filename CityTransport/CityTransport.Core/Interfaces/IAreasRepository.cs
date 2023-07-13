using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;

namespace CityTransport.Core.Interfaces
{
    public interface IAreasRepository
    {
        Task<Area> GetAreaByIdAsync(int id);

        Task<IReadOnlyList<Area>> GetAreasAsync();
    }
}
