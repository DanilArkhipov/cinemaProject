namespace SeriallizatioData
{
    public class UserSession
    {
        public int Id;
        public string Password;
        public string Login;

        public UserSession()
        {
            
        }

        public UserSession(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
    }
}