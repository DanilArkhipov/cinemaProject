using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.HtmlContentMakers;

namespace WebSiteCinema.Pages
{
    public class Schedule : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        [BindProperty(Name = "age",SupportsGet = true)]
        public string Age { get; set; }
        [BindProperty(Name = "search",SupportsGet = true)]
        public string Search { get; set; }
        [BindProperty(Name = "genre",SupportsGet = true)]
        public string Genre { get; set; }
        public Schedule(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}