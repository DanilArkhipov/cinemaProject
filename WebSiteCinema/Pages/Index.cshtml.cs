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
            Users usr = new Users()
            {
                login = "asfd",
                password = "adsf",
                status = (byte)1,
                role = (byte)1,
                email = "asdf",
                phone = "asdfsdf",
            }; 
            SqlServerRepository<Users> rep = new SqlServerRepository<Users>();
            rep.Insert(usr);
        }
    }
}