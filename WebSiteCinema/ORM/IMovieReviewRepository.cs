using System.Collections.Generic;
using System.Threading.Tasks;
using WebSiteCinema.Models;

namespace ORM
{
    public interface IMovieReviewRepository
    {
        Task<IEnumerable<MovieReview>> GetByUserLoginAndMovieId(string login, int id);
        public Task InsertAsync(MovieReview review);
    }
}