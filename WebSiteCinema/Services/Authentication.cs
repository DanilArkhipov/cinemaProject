using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ORM;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;

namespace WebSiteCinema.Services
{
    public class Authentication:IAuthentication
    {
        private const string SessionKey = "Authentification";
        private readonly UnitOfWork _unitOfWork;
        private readonly HttpContext _context;
        public Authentication(UnitOfWork unitOfWork,IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _context = contextAccessor.HttpContext;
        }
        public async Task AuthenticateAsync(UserData data,bool useCookie=false)
        {
            var user = await _unitOfWork.UsersRepository.GetByLoginAsync(data.Login);
            if (user!=null && user.password==data.Password && user.status==(short)UserStatus.Active)
            {
                if (!Authenticated)
                {
                    if (useCookie)
                    {
                        _context.Response.Cookies.SetUserData(SessionKey,data);
                    }
                    _context.Session.SetUserSessionData(SessionKey, data);
                }
            }
        }

        public async Task AuthenticateAsync()
        {
            if (!Authenticated && _context.Request.Cookies.ContainsKey(SessionKey))
            {
                await AuthenticateAsync(_context.Request.Cookies.GetUserData(SessionKey));
            }
        }

        public void RemoveAuthentication()
        {
            if(Authenticated)
                _context.Session.Remove(SessionKey);
            if (_context.Request.Cookies.ContainsKey(SessionKey))
            {
                _context.Response.Cookies.Delete(SessionKey);
            }
        }

        public bool Authenticated
        {
            get { return _context.Session.Keys.Any(k => k.Equals(SessionKey)); }

        }

        public UserData User => _context.Session.GetUserSessionData(SessionKey);
    }
}