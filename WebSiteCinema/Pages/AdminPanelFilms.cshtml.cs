using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class AdminPanelFilms : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IAuthorization _authorization;

        public AdminPanelFilms(UnitOfWork unitOfWork, IAuthorization authorization)
        {
            _unitOfWork = unitOfWork;
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

        public async Task OnGetDelete(int id)
        {
            try
            {
                await _unitOfWork.MovieRepository.DeleteAsync(id);
            }
            catch
            {
                RedirectToPage();
            }
        }
    }
}