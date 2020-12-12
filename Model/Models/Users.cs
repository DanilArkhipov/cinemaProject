using System;
using LinqToDB.Mapping;

namespace Model.Models
{
    [Table("users")]
    public class Users:Entity
    {
        private long id;
        [Column(Name = "id",IsPrimaryKey = true,IsIdentity = true)]
        public long Id { get; internal set; }

        private string login;
        [Column("login")]
        public string Login { get; internal set; }

        private string password;
        [Column("password")]
        public string Password { get; internal set; }

        private byte status;
        [Column("status")]
        public byte Status { get; internal set; }

        private byte role;
        [Column("role")]
        public byte Role { get; internal set; }

        private string email;
        [Column("email")]
        public string Email { get; internal set; }

        private string phone;
        [Column("phone")]
        public string Phone { get; internal set; }

        private byte[] avatar;
        [Column("avatar")]
        public byte[] Avatar { get; internal set; }

        public Users(
            long id,
            string login,
            string password,
            byte status,
            byte role,
            string email,
            string phone,
            byte[] avatar = null)
        {
            Id = id;
            Login = login;
            Password = password;
            Status = status;
            Role = role;
            Email = email;
            Phone = phone;
            Avatar = avatar;
        }

    }
}