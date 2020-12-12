using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.Models;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class Registration : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IDataHandler _dataHandler;

        public Registration(UnitOfWork unitOfWork,IDataHandler dataHandler)
        {
            _unitOfWork = unitOfWork;
            _dataHandler = dataHandler;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostRegistration(string name,string email,string repeat_password,string phone)
        {
            var user = new Users(name,_dataHandler.GetMD5Hash(repeat_password),email,phone,(short)UserStatus.Active,(short)UserRole.Default);
            try
            {
                if(_dataHandler.IsEmailValid(email) && _dataHandler.IsPhoneValid(phone))
                    await _unitOfWork.UsersRepository.InsertAsync(user);
                else return new StatusCodeResult(500);
            }
            catch
            {
                return new StatusCodeResult(500);
            }

            return RedirectToPage("Login");
        }
    }
}