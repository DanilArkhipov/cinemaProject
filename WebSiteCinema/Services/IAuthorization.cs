namespace WebSiteCinema.Services
{
    public interface IAuthorization
    {
        public bool Authenticated { get;}
        public UserRole UserRole { get; }
    }
}