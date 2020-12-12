using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;

namespace ORM
{
    public class PlaceRepository:UnitOfWork,IPlaceRepository
    {
        public PlaceRepository(LinqToDbConnectionOptions<UnitOfWork> options) : base(options)
        {
        }

        private ITable<Place> Place => GetTable<Place>();
        public async Task<IEnumerable<Place>> GetBySessionIdAsync(int session_id)
        {
            return await Place.Where(p => p.session_id == session_id).ToListAsync();
        }

        public async Task CreatePlacesAsync(int session_id, int row, int column)
        {
            
            if (row > 0 && column > 0)
            {
                for (int i = 1; i <= row; i++)
                {
                    for (int j = 1; j <= column; j++)
                    {
                        await Place.InsertWithInt32IdentityAsync(() => new Place()
                        {
                            name = string.Format("{0}-{1}-{2}",session_id,i,j),
                            session_id = session_id,
                            status = (short) PlaceStatus.Active,
                        });
                    }
                }
                
            }
        }

        public async Task<Place> GetByNameAsync(string name)
        {
            return await Place.Where(p => p.name == name).FirstOrDefaultAsync();
        }

        public async Task<Place> GetAsync(int id)
        {
            return await Place.Where(p => p.id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateStatus(string placeNumber,PlaceStatus status)
        {
            await Place.Where(p=>p.name==placeNumber).Set(place => place.status, (short)status).UpdateAsync();
        }
    }
}