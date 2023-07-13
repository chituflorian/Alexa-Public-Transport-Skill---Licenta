using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityTransport.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly IGenericRepository<Area> _areaRepo;

        public AreasController(IGenericRepository<Area> areaRepo)
        {
            _areaRepo = areaRepo;
        }

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
    }
}
