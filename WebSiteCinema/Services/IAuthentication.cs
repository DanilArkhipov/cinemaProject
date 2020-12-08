using System.Threading.Tasks;
using WebSiteCinema.DataStorage;

namespace WebSiteCinema.Services
{
    public interface IAuthentication
    {
        public Task AuthenticateAsync(UserData data,bool useCookie);
        public Task AuthenticateAsync();
        public void RemoveAuthentication();
        public bool Authenticated { get; }
        public UserData User { get;}
    }
}