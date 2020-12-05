using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.Models;

namespace WebSiteCinema.Pages
{
    public class Registration : PageModel
    {
        private UsersRepository usersRepository;

        public Registration(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public async Task OnPost(string login,string email,string phone,string password)
        {
            var user = new Users(login,password,email,phone);
            await usersRepository.InsertAsync(user);
        }
    }
}