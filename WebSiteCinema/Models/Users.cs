using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteCinema.Models
{
    [Table("users")]
    public class Users
    {
        [Column]
        public long id;
        [Column]
        public string login;
        [Column]
        public string password;
        [Column]
        public byte status;
        [Column]
        public byte role;
        [Column]
        public string email;
        [Column]
        public string phone;
        /*[Column]
        public byte[] avatar;*/
    }
}