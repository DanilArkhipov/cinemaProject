namespace WebSiteCinema.Services
{
    public interface IDataHandler
    {
        public string GetMD5Hash(string input);
        public bool IsPhoneValid(string input);
        public bool IsEmailValid(string input);

    }
}