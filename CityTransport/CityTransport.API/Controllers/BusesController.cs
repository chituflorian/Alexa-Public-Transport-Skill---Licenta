using AutoMapper;
using CityTransport.API.Models;
using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityTransport.API.Controllers
{
    [Route("RatBv/api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly IBusesRepository _busRepo;
        private readonly IMapper _mapper;

        public BusesController(IBusesRepository busRepo, IMapper mapper)
        {
            _busRepo = busRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses()
        {
            var buses = await _busRepo.GetBusesAsync();

            var busDTOs = _mapper.Map<IEnumerable<BusDTO>>(buses);
            return Ok(busDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
            var bus = await _busRepo.GetBusByIdAsync(id);

            if (bus == null)
            {
                return NotFound();
            }

            return Ok(bus);
        }

        [HttpGet("schedule")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetBusesIncludeSchedule()
        {
            var buses = await _busRepo.GetBusesWithScheduleAsync();
           
            var busWithScheduleDTOs = _mapper.Map<IEnumerable<BusWithScheduleDTO>>(buses);
            return Ok(busWithScheduleDTOs);
        }
    }
}
