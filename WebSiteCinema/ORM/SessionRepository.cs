using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Configuration;
using WebSiteCinema.Models;

namespace ORM
{
    public class SessionRepository:UnitOfWork,ISessionRepository
    {
        public SessionRepository(LinqToDbConnectionOptions<UnitOfWork> options) : base(options)
        {
        }

        private ITable<Session> Sessions => GetTable<Session>();
        public async Task Insert(Session session)
        {
            await Sessions.InsertWithInt32IdentityAsync(() => new Session()
            {
                film_id = session.film_id,
                date = session.date,
                time = session.time,
            });
        }

        public async Task<IEnumerable<Session>> GetAllByMovieId(int film_id)
        {
            return await Sessions.Where(s => s.film_id == film_id).ToListAsync();
        }
    }
}