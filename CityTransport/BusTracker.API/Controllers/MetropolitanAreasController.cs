using AutoMapper;
using BusTracker.API.Models;
using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using CityTransport.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityTransport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetropolitanAreasController : ControllerBase
    {
        private readonly IMetropolitanAreasRepository _repo;
        private readonly IMapper _mapper;

        public MetropolitanAreasController(IMetropolitanAreasRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/MetropolitanAreas
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MetropolitanAreaDTO>>> GetMetropolitanAreas()
        {
            var mareas = await _repo.GetMetropolitanAreasAsync();

            var mareaDTOs = _mapper.Map<IReadOnlyList<MetropolitanArea>, IReadOnlyList<MetropolitanAreaDTO>>(mareas);

            return Ok(mareaDTOs);
        }

        //// GET: api/MetropolitanAreas/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<MetropolitanArea>> GetMetropolitanArea(int id)
        //{
        //    var metropolitanArea = await _context.MetropolitanAreas.FindAsync(id);

        //    if (metropolitanArea == null)
        //    {
        //        return NotFound();
        //    }

        //    return metropolitanArea;
        //}

        //// GET: api/MetropolitanAreas/5/Cities
        //[HttpGet("{id}/Cities")]
        //public async Task<ActionResult<IEnumerable<City>>> GetCitiesInMetropolitanArea(int id)
        //{
        //    var metropolitanArea = await _context.MetropolitanAreas
        //        .Include(m => m.Cities)
        //        .FirstOrDefaultAsync(m => m.MetropolitanAreaId == id);


        //    if (metropolitanArea == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(metropolitanArea.Cities.ToList());
        //}
    }
}
