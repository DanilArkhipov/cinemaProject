using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private IDataHandler _dataHandler;
        public Login(IAuthentication authentication,IDataHandler dataHandler)
        {
            _authentication = authentication;
            _dataHandler = dataHandler;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostLogin(string login,string password,bool remember)
        {
            await _authentication.AuthenticateAsync(new UserData(login,_dataHandler.GetMD5Hash(password)), remember);
            if (_authentication.Authenticated)
            {
                return RedirectToPage("/Index");
            }

            return RedirectToPage("/Login");
        }
    }
}