using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CityTransport.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatBvController : ControllerBase
    {
        private readonly IGenericRepository<City> _cityRepo;
        private readonly IGenericRepository<MetropolitanArea> _metropolitanAreaRepo;
        private readonly IGenericRepository<Area> _areaRepo;
        private readonly IGenericRepository<Bus> _busRepo;
        private readonly IGenericRepository<BusStation> _busStationRepo;
        private readonly IGenericRepository<Schedule> _sheduleRepo;

        public RatBvController(IGenericRepository<City> cityRepo,
            IGenericRepository<MetropolitanArea> metropolitanAreaRepo,
            IGenericRepository<Area> areaRepo,
            IGenericRepository<Bus> busRepo,
            IGenericRepository<BusStation> busStationRepo,
            IGenericRepository<Schedule> sheduleRepo)
        {
            _cityRepo = cityRepo;
            _metropolitanAreaRepo = metropolitanAreaRepo;
            _areaRepo = areaRepo;
            _busRepo = busRepo;
            _busStationRepo = busStationRepo;
            _sheduleRepo = sheduleRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _cityRepo.GetAllAsync();

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _cityRepo.GetByIdAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // MetropolitanArea Controller

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetropolitanArea>>> GetMetropolitanAreas()
        {
            var metropolitanAreas = await _metropolitanAreaRepo.GetAllAsync();
            return Ok(metropolitanAreas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetropolitanArea>> GetMetropolitanArea(int id)
        {
            var metropolitanArea = await _metropolitanAreaRepo.GetByIdAsync(id);

            if (metropolitanArea == null)
            {
                return NotFound();
            }

            return Ok(metropolitanArea);
        }


        // Area Controller

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            var areas = await _areaRepo.GetAllAsync();
            return Ok(areas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            var area = await _areaRepo.GetByIdAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return Ok(area);
        }


        // Bus Controller

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses()
        {
            var buses = await _busRepo.GetAllAsync();
            return Ok(buses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
            var bus = await _busRepo.GetByIdAsync(id);

            if (bus == null)
            {
                return NotFound();
            }

            return Ok(bus);
        }


        // BusStation Controller

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


        // Schedule Controller

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            var schedules = await _sheduleRepo.GetAllAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(int id)
        {
            var schedule = await _sheduleRepo.GetByIdAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }


    }
}
