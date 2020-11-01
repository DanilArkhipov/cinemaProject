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

        public void OnGet()
        {
            Users usr1 = new Users()
            {
                login = "dddd",
                password = "pppp",
                status = (byte)1,
                role = (byte)1,
                email = "ffff",
                phone = "112223123",
            }; 
            Users usr2 = new Users()
            {
                login = "gspd",
                password = "rw",
                status = (byte)0,
                role = (byte)0,
                email = "gspd",
                phone = "88005553535",
            }; 
            SqlServerRepository<Users> rep = new SqlServerRepository<Users>();
            rep.Insert(usr1);
            rep.Insert(new []{usr1,usr2});
        }
    }
}