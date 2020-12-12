using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.Models;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class UserEdit : PageModel
    {
        private IWebHostEnvironment _hostEnvironment;
        private IAuthorization _authorization;
        private readonly UnitOfWork _unitOfWork;

        public UserEdit(UnitOfWork unitOfWork, IAuthorization authorization, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _authorization = authorization;
            _hostEnvironment = hostEnvironment;
        }

        [BindProperty(Name = "login", SupportsGet = true)]
        public string Login { get; set; }

        public IActionResult OnGet()
        {
            if (_authorization.UserRole != UserRole.Admin)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostChangeUser(
            short status,
            short role)
        {
            try
            {
                var oldUser = await _unitOfWork.UsersRepository.GetByLoginAsync(Login);
                var newUser = new Users()
                {
                    status = status,
                    role = role,
                };
                await _unitOfWork.UsersRepository.UpdateAsync(newUser,oldUser);

            }
            catch
            {
                return RedirectToPage();
            }

            return RedirectToPage("/AdminPanelUsers");
        }
    }
}