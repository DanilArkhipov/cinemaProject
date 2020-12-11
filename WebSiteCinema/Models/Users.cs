using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteCinema.Models
{
    public class Users
    {
        public string login;
        public string password;
        public short status;
        public short role;
        public string email;
        public string phone;

        public Users(
            string login,
            string password,
            string email,
            string phone,
            short status = 0,
            short role = 0)
        {
            this.login = login;
            this.password = password;
            this.status = status;
            this.role = role;
            this.email = email;
            this.phone = phone;
        }

        public Users()
        {
            
        }

    }
}