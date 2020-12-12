using System.Collections.Generic;
using System.Threading.Tasks;
using WebSiteCinema.Models;

namespace ORM
{
    public interface ISessionRepository
    {
        public Task Insert(Session session);
        Task<IEnumerable<Session>> GetAllByMovieId(int film_id);
        Task<Session> GetById(int id);
    }
}