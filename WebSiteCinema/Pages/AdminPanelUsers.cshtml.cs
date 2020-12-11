using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class AdminPanelUsers : PageModel
    {
        private readonly IAuthorization _authorization;

        public AdminPanelUsers(IAuthorization authorization)
        {
            _authorization = authorization;
        }
        public IActionResult OnGet()
        {
            if (_authorization.UserRole != UserRole.Admin)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}