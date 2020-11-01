using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository;
using WebSiteCinema.Models;

namespace WebSiteCinema.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        async public void OnGet()
        {
            Users usr1 = new Users
            (
                default(long),
                "dddd",
                "pppp",
                (byte)1,
                (byte)1,
                "ffff",
                "112223123"
            ); 
            Users usr2 = new Users
            (
                default(long),
                "gspd",
                "rw",
                (byte)0,
                (byte)0,
                "gspd",
                "88005553535"
            );
            SqlServerRepository<Users> rep = new SqlServerRepository<Users>();
            await rep.InsertAsync(usr1);
            await rep.InsertAsync(new []{usr1,usr2});
            var res1 = await rep.GetByIdAsync(1);
            Console.WriteLine(res1.FirstOrDefault().id);
            var res2 = await rep.GetAllAsync();
            foreach (var v in res2)
            {
                Console.WriteLine(v.id);
            }
            await rep.DeleteAsync(54);
        }
    }
}