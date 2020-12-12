using System;

namespace WebSiteCinema.Models
{
    public class Session
    {
        public int id;
        public int film_id;
        public DateTime date;
        public TimeSpan time;

        public Session(int film_id, DateTime date, TimeSpan time,int id = 0)
        {
            this.film_id = film_id;
            this.date = date;
            this.time = time;
        }
        
        public Session(){}
    }
    
}