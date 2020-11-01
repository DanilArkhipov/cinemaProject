namespace WebSiteCinema.Models
{
    public class movie_genre
    {
        public long movie_id;
        public long genre_id;

        public movie_genre(long movie_id, long genre_id)
        {
            this.movie_id = movie_id;
            this.genre_id = genre_id;
        }
    }
}