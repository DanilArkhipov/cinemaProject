using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.Models;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class AdminPanelSchedule : PageModel
    {
        private readonly IAuthorization _authorization;
        private readonly UnitOfWork _unitOfWork;

        public AdminPanelSchedule(IAuthorization authorization,UnitOfWork unitOfWork)
        {
            _authorization = authorization;
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet()
        {
            if (_authorization.UserRole != UserRole.Admin)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddMovieToSchedule(int film_id,DateTime date,TimeSpan time)
        {
            try
            {
                await _unitOfWork.SessionRepository.Insert(new Session(film_id, date, time));
            }
            catch
            {
                return RedirectToPage();
            }
            return RedirectToPage("/AdminPanelFilms");
        }
    }
}