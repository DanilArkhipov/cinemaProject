namespace WebSiteCinema.Models
{
    public class Place
    {
        public int session_id;
        public short status;
        public string name;
        public int id;

        public Place(int session_id, short status, string name,int id=0)
        {
            this.session_id = session_id;
            this.status = status;
            this.name = name;
            this.id = id;
        }
        public Place(){}
    }
    
}