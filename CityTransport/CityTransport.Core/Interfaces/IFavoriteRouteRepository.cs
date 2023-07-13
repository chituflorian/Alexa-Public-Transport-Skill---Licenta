using System.Collections.Generic;
using System.Threading.Tasks;
using CityTransport.Core.Data;

namespace CityTransport.Core.Interfaces
{
    public interface IFavoriteRouteRepository
    {
        Task<IEnumerable<FavoriteBusRoute>> GetFavoriteRoutes();
        Task<FavoriteBusRoute> GetFavoriteRouteById(int id);
        Task AddFavoriteRoute(FavoriteBusRoute favoriteRoute);
        void UpdateFavoriteRoute(FavoriteBusRoute favoriteRoute);
        void DeleteFavoriteRoute(FavoriteBusRoute favoriteRoute);
        Task<int> GetFavoriteRoutesCount();
        Task<bool> DoesFavoriteRouteExist(string busName, string stationFrom, string stationTo);
        Task SaveAsync();
    }
}
