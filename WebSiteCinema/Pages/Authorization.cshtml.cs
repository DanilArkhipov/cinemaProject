using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using WebSiteCinema.Models;

namespace WebSiteCinema.Pages
{
    public class Authorization : PageModel
    {
        public async void OnPost(string login,string password)
        {
            var rep = new SqlServerRepository<Users>();
            var users = await rep.GetAllAsync();
            var res = users.Where(x => x.login == login && x.password == password).FirstOrDefault();
            if (res!=null) Console.WriteLine(res.id);
        }
    }
}