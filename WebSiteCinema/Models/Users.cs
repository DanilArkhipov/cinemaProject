using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteCinema.Models
{
    public class Users
    {
        public long id;
        public string login;
        public string password;
        public short status;
        public short role;
        public string email;
        public string phone;
        public byte[] avatar;

        public Users(
            long id,
            string login,
            string password,
            short status,
            short role,
            string email,
            string phone,
            byte[] avatar = null)
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

    }
}