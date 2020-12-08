using System;

namespace WebSiteCinema.DataStorage
{
    [Serializable]
    public class UserData
    {
        public string Password { get; set; }
        public string Login { get; set; }

        public UserData()
        {
            
        }

        public UserData(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}