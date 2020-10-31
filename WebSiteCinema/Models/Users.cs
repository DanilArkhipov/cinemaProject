namespace WebSiteCinema.Models
{
    public class Users
    {
        public long id;
        public string login;
        public string password;
        public byte status;
        public byte role;
        public string email;
        public string phone;
        public byte[] avatar;
    }
}