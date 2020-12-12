using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.Models;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class FilmCreate : PageModel
    {
        private IWebHostEnvironment _hostEnvironment;
        private IAuthorization _authorization;
        private readonly UnitOfWork _unitOfWork;
        public FilmCreate(UnitOfWork unitOfWork, IAuthorization authorization,IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _authorization = authorization;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult OnGet()
        {
            if (_authorization.UserRole != UserRole.Admin)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreateMovie(
            string name,
            string category, 
            string age_rating, 
            string actors,
            TimeSpan duration, 
            string description, 
            DateTime release_date, 
            IFormFile picture)
        {
            try
            {
                var secondPartPath =  Path.Combine("images", "films", picture.FileName);
                var str = _hostEnvironment.WebRootPath;
                var file = Path.Combine(_hostEnvironment.WebRootPath, secondPartPath);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await picture.CopyToAsync(fileStream);
                }

                await _unitOfWork.MovieRepository.InsertAsync(new Movie(name, duration,description, release_date,
                    age_rating,
                    secondPartPath, actors,category ));
            }
            catch
            {
                return Page();
            }

            return RedirectToPage("/AdminPanelFilms");
        }
    }
}