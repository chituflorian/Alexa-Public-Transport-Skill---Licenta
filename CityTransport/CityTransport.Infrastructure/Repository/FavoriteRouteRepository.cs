using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using CityTransport.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CityTransport.Infrastructure.Repository
{
    public class FavoriteRouteRepository : IFavoriteRouteRepository
    {
        private readonly RatBVTransportContext _context;
        public FavoriteRouteRepository(RatBVTransportContext context)
        {
            _context = context;
        }

        public async Task AddFavoriteRoute(FavoriteBusRoute favoriteRoute)
        {
            await _context.Favorites.AddAsync(favoriteRoute);
        }

        public void UpdateFavoriteRoute(FavoriteBusRoute favoriteRoute)
        {
            _context.Favorites.Update(favoriteRoute);
        }

        public void DeleteFavoriteRoute(FavoriteBusRoute favoriteRoute)
        {
            _context.Favorites.Remove(favoriteRoute);
        }

        public async Task<IEnumerable<FavoriteBusRoute>> GetFavoriteRoutes()
        {
            return await _context.Favorites.ToListAsync();
        }

        public async Task<FavoriteBusRoute> GetFavoriteRouteById(int id)
        {
            return await _context.Favorites.FindAsync(id);
        }

        public async Task<int> GetFavoriteRoutesCount()
        {
            return await _context.Favorites.CountAsync();
        }

        public async Task<bool> DoesFavoriteRouteExist(string busName, string stationFrom, string stationTo)
        {
            return await _context.Favorites.AnyAsync(fr => fr.BusName == busName && fr.StationFrom == stationFrom && fr.StationTo == stationTo);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
