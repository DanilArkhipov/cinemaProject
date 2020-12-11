using System;
using System.IO;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.Models;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class FilmEdit : PageModel
    {
        private IWebHostEnvironment _hostEnvironment;
        private IAuthorization _authorization;
        private readonly UnitOfWork _unitOfWork;
        public FilmEdit(UnitOfWork unitOfWork, IAuthorization authorization,IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _authorization = authorization;
            _hostEnvironment = hostEnvironment;
        }
        
        [BindProperty(Name = "id",SupportsGet = true)]
        public int Id { get; set; }
        
        public IActionResult OnGet()
        {
            if (_authorization.UserRole != UserRole.Admin)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostChangeMovie(
            string name,
            string category, 
            string age_rating, 
            string actors,
            TimeSpan duration, 
            string description, 
            DateTime release_date, 
            IFormFile picture,
            short status)
        {
            try
            {
                var oldMovie = await _unitOfWork.MovieRepository.GetByIdAsync(Id);
                if (picture != null)
                {
                    var secondPartPath = Path.Combine("images", "films", picture?.FileName);
                    var str = _hostEnvironment.WebRootPath;
                    var file = Path.Combine(_hostEnvironment.WebRootPath, secondPartPath);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await picture.CopyToAsync(fileStream);
                    }


                    await _unitOfWork.MovieRepository.UpdateAsync(oldMovie,new Movie(name, duration, description, release_date,
                        age_rating,
                        secondPartPath, actors, category,status));
                }
                else
                {
                    await _unitOfWork.MovieRepository.UpdateAsync(oldMovie,new Movie(name, duration, description, release_date,
                        age_rating,
                        null, actors, category,status));
                }
            }
            catch 
            {
                return Page();
            }

            return RedirectToPage("/AdminPanelFilms");
        }
    }
}