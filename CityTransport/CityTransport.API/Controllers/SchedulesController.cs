using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CityTransport.API.Controllers
{
    [ApiController]
    [Route("RatBv/api/[controller]")]
    public class SchedulesController : ControllerBase
    {
        private readonly IGenericRepository<Schedule> _sheduleRepo;

        public SchedulesController(IGenericRepository<Schedule> sheduleRepo)
        {
            _sheduleRepo = sheduleRepo;
        }

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
