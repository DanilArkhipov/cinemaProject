using System;

namespace WebSiteCinema.Models
{
    public class MovieReview
    {
        public int id;
        public string user_login;
        public int movie_id;
        public string review;
        public DateTime date;

        public MovieReview( string user_login, int movie_id, string review, DateTime date, int id = 0)
        {
            this.id = id;
            this.date = date;
            this.movie_id = movie_id;
            this.review = review;
            this.user_login = user_login;
        }
        public MovieReview(){}
    }
}