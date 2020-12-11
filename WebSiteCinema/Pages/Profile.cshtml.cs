using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class Profile : PageModel
    {
        private readonly IAuthentication _authentication;
        private readonly UnitOfWork _unitOfWork;
        private readonly IDataHandler _dataHandler;

        public Profile(IAuthentication authentication,UnitOfWork unitOfWork,IDataHandler dataHandler)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
            _dataHandler = dataHandler;
        }
        public IActionResult OnGet()
        {
            if (!_authentication.Authenticated)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnGetLogout()
        {
            if (!_authentication.Authenticated)
            {
                return RedirectToPage("/Index");
            }

            _authentication.RemoveAuthentication();
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostChangeUser(string phone,string email,string old_password,string new_password,string repeat_password)
        {
            try
            {
                var dataCorrectnessFlag = _dataHandler.IsEmailValid(email) && _dataHandler.IsPhoneValid(phone);
                if (old_password != null && new_password != null && repeat_password != null &&
                    _dataHandler.GetMD5Hash(old_password) == _authentication.User.Password && new_password == repeat_password && dataCorrectnessFlag)
                {
                    var oldUser = await _unitOfWork.UsersRepository.GetByLoginAsync(_authentication.User.Login);
                    var user = new Users()
                    {
                        phone = phone,
                        email = email,
                        password = _dataHandler.GetMD5Hash(repeat_password),
                        role = oldUser.role,
                        status = oldUser.status,
                    };
                    await _unitOfWork.UsersRepository.UpdateAsync(user, oldUser);
                    _authentication.RemoveAuthentication();
                    await _authentication.AuthenticateAsync(new UserData(oldUser.login, user.password));
                    return RedirectToPage();
                }

                else if (old_password == null && new_password == null && repeat_password == null && dataCorrectnessFlag)
                {
                    var oldUser = await _unitOfWork.UsersRepository.GetByLoginAsync(_authentication.User.Login);
                    var user = new Users()
                    {
                        phone = phone,
                        email = email,
                        status = oldUser.status,
                        role = oldUser.role,
                    };
                    await _unitOfWork.UsersRepository.UpdateAsync(user, oldUser);
                    return RedirectToPage();
                }
                else
                {
                    return RedirectToPage();
                }
            }
            catch
            {
                return RedirectToPage();
            }
        }
    }
}