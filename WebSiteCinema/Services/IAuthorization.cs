using WebSiteCinema.DataStorage;

namespace WebSiteCinema.Services
{
    public interface IAuthorization
    {
        public bool Authenticated { get;}
        public UserRole UserRole { get; }
        public UserData UserData { get; }
    }
}