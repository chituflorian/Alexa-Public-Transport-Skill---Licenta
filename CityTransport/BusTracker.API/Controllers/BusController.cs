using AutoMapper;
using BusTracker.API.Models;
using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusesRepository _busStationsRepo;
        private readonly IMapper _mapper;

        public BusController(IBusesRepository repo, IMapper mapper)
        {
            _busStationsRepo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet("stations/{stationName}/buses")]
        //public async Task<ActionResult<IReadOnlyList<BusStationDTO>>> GetBusesOnStation(string stationName)
        //{
        //    var buses = await _repo.GetBusesByStationName(stationName);
        //    var busDTOs = _mapper.Map<List<BusStationDTO>>(buses);
        //    return Ok(busDTOs);
        //}


        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<BusDTO>>> GetBuses()
        {
            // Retrieve the list of buses for the bus station
            var buses = await _busStationsRepo.GetBusesAsync();

           
            // Map the buses to DTOs and return the result
            var busDTOs = _mapper.Map<IReadOnlyList<BusDTO>>(buses);
            return Ok(buses);
        }

        [HttpGet("{stationName}/buses")]
        public async Task<ActionResult<IReadOnlyList<BusDTO>>> GetBuses(string stationName)
        {
            // Retrieve the list of buses for the bus station
            var buses = await _busStationsRepo.GetBusesByStationName(stationName);

            if (buses == null)
            {
                return NotFound($"Bus station with name {stationName} not found.");
            }

            // Map the buses to DTOs and return the result
            var busDTOs = _mapper.Map<IReadOnlyList<BusDTO>>(buses);
            return Ok(busDTOs);
        }

        [HttpGet("stations/{stationName}/buses")]
        public async Task<ActionResult<IReadOnlyList<BusDTO>>> GetBusesOnStation(string stationName)
        {
            // Retrieve the list of buses for the bus station
            var buses = await _busStationsRepo.GetBusesByStationName(stationName);

            if (buses == null)
            {
                return NotFound($"Bus station with name {stationName} not found.");
            }

            // Map the buses to DTOs and return the result
            var busDTOs = _mapper.Map<IReadOnlyList<BusDTO>>(buses);
            return Ok(busDTOs);
        }

        [HttpGet("stations/{stationName}/schedules")]
        public async Task<ActionResult<IReadOnlyList<BusDTO>>> GetSchedulesOnStation(string stationName)
        {
            // Retrieve the list of buses for the bus station
            var buses = await _busStationsRepo.GetBusesByStationName(stationName);

            if (buses == null)
            {
                return NotFound($"Bus station with name {stationName} not found.");
            }

            // Map the buses to DTOs and return the result
            var busWithScheduleDTOs = _mapper.Map<IReadOnlyList<BusWithScheduleDTO>>(buses);
            return Ok(busWithScheduleDTOs);
        }

        [HttpGet("stations/{stationName}/schedules/currentTime")]
        public async Task<ActionResult<IReadOnlyList<BusDTO>>> GetCurrentTimeSchedulesOnStation(string stationName)
        {
            // Retrieve the list of buses for the bus station
            var buses = await _busStationsRepo.GetBusesByStationNameWithScheduleAsync(stationName);

            if (buses == null)
            {
                return NotFound($"Bus station with name {stationName} not found.");
            }

            // Map the buses to DTOs and return the result
           
            return Ok(buses);
        }

        [HttpGet("{stationName}/{terminal}/buses")]
        public async Task<ActionResult<IReadOnlyList<BusDTO>>> GetBusesOnRouteAll(string stationName, string terminal)
        {
            var buses = await _busStationsRepo.GetBusesOnTheSpecifiedRouteAsync(stationName, terminal);

            if (buses == null)
            {
                return NotFound($"Bus station with name {stationName} not found.");
            }

            var result = new
            {
                StationName = stationName,
                Terminal = terminal,
                Buses = buses,
            };

            return Ok(result);
        }

        [HttpGet("{stationName}/{terminal}/{line}")]
        public async Task<ActionResult<IReadOnlyList<BusDTO>>> GetBusesOnRoute(string stationName, string terminal, string line)
        {
            var buses = await _busStationsRepo.GetBusesOnTheSpecifiedRouteAsync(stationName, terminal, line);

            if (buses == null)
            {
                return NotFound($"Bus with name {line} not found.");
            }

            var result = new
            {
                StationName = stationName,
                Terminal = terminal,
                Buses = buses,
            };

            return Ok(result);
        }

        [HttpGet("{stationName}/{terminal}/{line}/nextBusTime")]
        public async Task<ActionResult<int?>> GetNextBusTime(string stationName, string terminal, string line)
        {
            var timeUntilNextBus = await _busStationsRepo.GetNextBusTimeAsync(stationName, terminal, line);

            if (timeUntilNextBus == null)
            {
                return NotFound($"No upcoming bus found on line {line} from station {stationName} to terminal {terminal}.");
            }

            var result = new
            {
                StationName = stationName,
                Terminal = terminal,
                Line = line,
                TimeUntilNextBus = timeUntilNextBus
            };

            return Ok(result);
        }

    }
}
