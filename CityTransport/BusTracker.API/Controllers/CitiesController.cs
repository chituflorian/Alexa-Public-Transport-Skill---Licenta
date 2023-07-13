using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusTracker.API.Controllers
{
    [ApiController]
    [Route("RatBv/api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesRepository _repo;

        public CitiesController(ICitiesRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _repo.GetCitiesAsync();

            return Ok(cities);
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _repo.GetCityByIdAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);           
        }
    }
}