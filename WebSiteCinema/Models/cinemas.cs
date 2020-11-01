namespace WebSiteCinema.Models
{
    public class cinemas
    {
        public long id;
        public string name;
        public string address;

        public cinemas(long id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
    }
}