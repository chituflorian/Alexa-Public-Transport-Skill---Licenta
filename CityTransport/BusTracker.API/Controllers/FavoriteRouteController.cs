using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteRouteController : ControllerBase
    {
        private readonly IFavoriteRouteRepository _repo;

        public FavoriteRouteController(IFavoriteRouteRepository repo)
        {
            _repo = repo;
        }

        // GET: api/FavoriteRoute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteBusRoute>>> GetFavoriteRoutes()
        {
            return Ok(await _repo.GetFavoriteRoutes());
        }

        // GET: api/FavoriteRoute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteBusRoute>> GetFavoriteRoute(int id)
        {
            var favoriteRoute = await _repo.GetFavoriteRouteById(id);

            if (favoriteRoute == null)
            {
                return NotFound();
            }

            return Ok(favoriteRoute);
        }
        // POST: api/FavoriteRoute
        [HttpPost]
        public async Task<ActionResult<FavoriteBusRoute>> PostFavoriteRoute(FavoriteBusRoute favoriteRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if maximum limit of favorite routes is reached
            if (await _repo.GetFavoriteRoutesCount() >= 5)
            {
                return BadRequest("You have reached the maximum limit of favorite routes.");
            }

            // Check if the route already exists
            if (await _repo.DoesFavoriteRouteExist(favoriteRoute.BusName, favoriteRoute.StationFrom, favoriteRoute.StationTo))
            {
                return BadRequest("This route already exists in your favorites.");
            }

            await _repo.AddFavoriteRoute(favoriteRoute);
            await _repo.SaveAsync();

            return CreatedAtAction(nameof(GetFavoriteRoute), new { id = favoriteRoute.RouteId }, favoriteRoute);
        }

        // GET: api/FavoriteRoute/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetFavoriteRoutesCount()
        {
            return Ok(await _repo.GetFavoriteRoutesCount());
        }

        // PUT: api/FavoriteRoute/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteRoute(int id, FavoriteBusRoute favoriteRoute)
        {
            if (id != favoriteRoute.RouteId)
            {
                return BadRequest();
            }

            var existingFavoriteRoute = await _repo.GetFavoriteRouteById(id);
            if (existingFavoriteRoute == null)
            {
                return NotFound();
            }

            existingFavoriteRoute = favoriteRoute;
            _repo.UpdateFavoriteRoute(existingFavoriteRoute);
            await _repo.SaveAsync();

            return NoContent();
        }

        // DELETE: api/FavoriteRoute/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteRoute(int id)
        {
            var favoriteRoute = await _repo.GetFavoriteRouteById(id);
            if (favoriteRoute == null)
            {
                return NotFound();
            }

            _repo.DeleteFavoriteRoute(favoriteRoute);
            await _repo.SaveAsync();

            return NoContent();
        }
    }
}
