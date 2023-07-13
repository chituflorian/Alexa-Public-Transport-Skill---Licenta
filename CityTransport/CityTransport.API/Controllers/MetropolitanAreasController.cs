using AutoMapper;
using CityTransport.API.Models;
using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}