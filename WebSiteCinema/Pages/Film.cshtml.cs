using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSiteCinema.Pages
{
    public class Film : PageModel
    {
        [BindProperty(Name = "id",SupportsGet = true)]
        public int Id { get; set; }
        public void OnGet()
        {

        }
    }
}