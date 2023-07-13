using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;

namespace CityTransport.Core.Interfaces
{
    /// <summary>
    /// Interface for accessing cities data in a repository.
    /// </summary>
    public interface ICitiesRepository
    {
        /// <summary>
        /// Asynchronously retrieves a single city object by its ID.
        /// </summary>
        /// <param name="id">The ID of the city to retrieve.</param>
        /// <returns>A task representing a single City object.</returns>
        Task<City> GetCityByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves a read-only list of all city objects.
        /// </summary>
        /// <returns>A task representing a read-only list of City objects.</returns>
        Task<IReadOnlyList<City>> GetCitiesAsync();
    }
}
