using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityTransport.API.Controllers
{
    [ApiController]
    [Route("RatBv/api/[controller]")]
    public class BusStationsController : ControllerBase
    {
        private readonly IGenericRepository<BusStation> _busStationRepo;

        public BusStationsController(IGenericRepository<BusStation> busStationRepo)
        {
            _busStationRepo = busStationRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusStation>>> GetBusStations()
        {
            var busStations = await _busStationRepo.GetAllAsync();
            return Ok(busStations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusStation>> GetBusStation(int id)
        {
            var busStation = await _busStationRepo.GetByIdAsync(id);

            if (busStation == null)
            {
                return NotFound();
            }

            return Ok(busStation);
        }
    }
}

