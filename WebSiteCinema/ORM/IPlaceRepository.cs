using System.Collections.Generic;
using System.Threading.Tasks;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;

namespace ORM
{
    public interface IPlaceRepository
    {
        public Task<IEnumerable<Place>> GetBySessionIdAsync(int session_id);
        public Task CreatePlacesAsync(int session_id, int row, int column);
        public Task<Place> GetByNameAsync(string name);
        public Task<Place> GetAsync(int id);
        public Task UpdateStatus(string placeNumber,PlaceStatus status);
    }
}