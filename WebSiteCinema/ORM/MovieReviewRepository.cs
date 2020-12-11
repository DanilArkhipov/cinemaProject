using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Configuration;
using WebSiteCinema.Models;

namespace ORM
{
    public class MovieReviewRepository:UnitOfWork,IMovieReviewRepository
    {
        public MovieReviewRepository(LinqToDbConnectionOptions<UnitOfWork> options) : base(options)
        {
        }

        private ITable<MovieReview> Reviews => GetTable<MovieReview>();
        public async Task<IEnumerable<MovieReview>> GetByUserLoginAndMovieId(string login, int id)
        {
            return await Reviews.Where(r => r.movie_id == id && r.user_login == login).ToListAsync();
        }

        public async Task InsertAsync(MovieReview review)
        {
            await Reviews.InsertWithInt32IdentityAsync(() => new MovieReview()
            {
                user_login = review.user_login,
                review = review.review,
                date = review.date,
                movie_id = review.movie_id
            });
        }
    }
}