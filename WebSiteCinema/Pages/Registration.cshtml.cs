using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using WebSiteCinema.Models;

namespace WebSiteCinema.Pages
{
    public class Registration : PageModel
    {
        public void OnGet()
        {
            
        }

        async public void OnPostAsync(string login,string password,string email,string phone)
        {
            var user = new Users(0,login,password,0,0,email,phone);
            SqlServerRepository<Users> rep = new SqlServerRepository<Users>();
            await rep.InsertAsync(user);
        }
    }
}