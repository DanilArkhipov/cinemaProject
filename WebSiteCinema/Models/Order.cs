using System;

namespace WebSiteCinema.Models
{
    public class Order
    {
        public int id;
        public int place_id;
        public string user_login;
        public DateTime created;
        public string code;

        public Order(int place_id, string user_login, DateTime created, string code,int id = 0)
        {
            this.place_id = place_id;
            this.user_login = user_login;
            this.created = created;
            this.code = code;
            this.id = id;
        }
        
        public  Order(){}
    }
    
}