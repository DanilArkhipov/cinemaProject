using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class Login : PageModel
    {
        private IAuthentication _authentication;
        public Login(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        public void OnGet()
        {
            
        }

        public async Task OnPostLogin(string login,string password,bool remember)
        {
            await _authentication.AuthenticateAsync(new UserData(login,password), remember);
        }
    }
}