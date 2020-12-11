using System;

namespace WebSiteCinema.Models
{
    public class Movie
    {
        public int id;
        public string name;
        public short status;
        public TimeSpan duration;
        public string description;
        public DateTime release_date;
        public string age_rating;
        public string poster;
        public string actors;
        public string category;

        public Movie(
            string name,
            TimeSpan duration, 
            string description,
            DateTime release_date, 
            string age_rating,
            string poster,
            string actors,
            string category,
            short status = 0,
            int id = 0)
        {
            this.name = name;
            this.status = status;
            this.duration = duration;
            this.description = description;
            this.release_date = release_date;
            this.age_rating = age_rating;
            this.poster = poster;
            this.category = category;
            this.actors = actors;
            this.id = id;
        }

        public Movie(){}
    }

}