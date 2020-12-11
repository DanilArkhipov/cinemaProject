using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Configuration;
using WebSiteCinema.Models;

namespace ORM
{
    public class MovieRepository:UnitOfWork,IMovieRepository
    {
        public MovieRepository(LinqToDbConnectionOptions<UnitOfWork> options)
            : base(options)
        {
            
        }

        private ITable<Movie> Movie => GetTable<Movie>();
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await  Movie.Select(x=>x).ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await Movie.Where(m=>m.id == id).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(Movie movie)
        {
            await Movie.InsertWithInt32IdentityAsync(() => new Movie()
            {
                actors = movie.actors,
                age_rating = movie.age_rating,
                description = movie.description,
                duration = movie.duration,
                name = movie.name,
                poster = movie.poster,
                release_date = movie.release_date,
                status = movie.status,
                category = movie.category,
            });
        }

        public async Task DeleteAsync(Movie movie)
        {
            await Movie.Where(m => m.id.Equals(movie.id)).DeleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await Movie.Where(m => m.id == id).DeleteAsync();
        }

        public async Task UpdateAsync(Movie oldMovie,Movie newMovie)
        {
            await Movie.UpdateAsync(movie => new Movie()
            {
                actors = newMovie.actors ?? oldMovie.actors,
                age_rating = newMovie.age_rating ?? oldMovie.age_rating,
                category = newMovie.category ?? oldMovie.category,
                description = newMovie.description ?? oldMovie.description,
                duration = newMovie.duration == null ? oldMovie.duration : newMovie.duration,
                release_date = newMovie.release_date == null ? oldMovie.release_date : newMovie.release_date,
                name = newMovie.name ?? oldMovie.name,
                poster = newMovie.poster ?? oldMovie.poster,
                status = newMovie.status == null ? oldMovie.status : newMovie.status,
                
            });
        }
    }
}