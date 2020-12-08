using Microsoft.AspNetCore.Http;
using ORM;
using WebSiteCinema.Models;

namespace WebSiteCinema.Services
{
    public class Authorization:IAuthorization
    {
        private readonly IAuthentication _authentication;
        private readonly UsersRepository _usersRepository;
        public bool Authenticated => _authentication.Authenticated;

        public UserRole UserRole
        {
            get 
            {
                var user = _usersRepository.GetByLoginAsync(_authentication.User.Login).Result;
                return (UserRole) user.role;
            }
        }


        public Authorization(IAuthentication authentication,UsersRepository usersRepository)
        {
            _authentication = authentication;
            _usersRepository = usersRepository;
        }
    }
}