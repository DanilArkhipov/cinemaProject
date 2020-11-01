namespace WebSiteCinema.Models
{
    public class genre
    {
        public long id;
        public string description;

        public genre(long id, string description)
        {
            this.id = id;
            this.description = description;
        }
    }
}