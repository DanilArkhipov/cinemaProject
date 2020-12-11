using Microsoft.AspNetCore.Http;
using ORM;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Models;

namespace WebSiteCinema.Services
{
    public class Authorization:IAuthorization
    {
        private readonly IAuthentication _authentication;
        private readonly UnitOfWork _unitOfWork;
        public bool Authenticated => _authentication.Authenticated;

        public UserRole UserRole
        {
            get 
            {
                if (Authenticated)
                {
                    var user = _unitOfWork.UsersRepository.GetByLoginAsync(_authentication.User.Login).Result;
                    return (UserRole) user.role;
                }

                return UserRole.NonAuthenticated;
            }
        }

        public UserData UserData => _authentication.User;


        public Authorization(IAuthentication authentication,UnitOfWork unitOfWork)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
        }
    }
}