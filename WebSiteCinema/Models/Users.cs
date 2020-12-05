using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteCinema.Models
{
    public class Users
    {
        public int id;
        public string login;
        public string password;
        public short status;
        public short role;
        public string email;
        public string phone;
        public byte[] avatar;

        public Users(
            string login,
            string password,
            string email,
            string phone,
            short status = 0,
            short role = 0,
            byte[] avatar = null,
            int id = 0)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.status = status;
            this.role = role;
            this.email = email;
            this.phone = phone;
            this.avatar = avatar;
        }

        public Users()
        {
            
        }

    }
}