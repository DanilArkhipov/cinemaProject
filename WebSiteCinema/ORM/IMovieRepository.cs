using System.Collections.Generic;
using System.Threading.Tasks;
using WebSiteCinema.Models;

namespace ORM
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetAllAsync();
        public Task<Movie> GetByIdAsync(int id);
        public Task InsertAsync(Movie movie);
        public Task DeleteAsync(Movie movie);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(Movie oldMovie, Movie newMovie);
    }
}