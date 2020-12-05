using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using SeriallizatioData;
using WebSiteCinema.Authorization;
using WebSiteCinema.Models;

namespace WebSiteCinema.Pages
{
    public class Login : PageModel
    {
        private HttpContext context;
        private IUsersRepository _usersRepository;
        public Login(IHttpContextAccessor contextAccessor,UsersRepository usersRepository)
        {
            context = contextAccessor.HttpContext;
            _usersRepository = usersRepository;
        }
        public void OnGet()
        {
            
        }

        public async Task OnPostLogin(string login,string password,bool remember)
        {
            if (remember == false)
            {
                var user = await _usersRepository.GetByLoginAsync(login);
                if (user.login == login)
                {
                    context.Session.SetUserSessionData("User", new UserSession());
                }
            }
        }
    }
}