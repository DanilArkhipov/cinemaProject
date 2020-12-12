using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace WebSiteCinema.Services
{
    public class DataHandler:IDataHandler
    {
        public string GetMD5Hash(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            MD5 md5  = MD5CryptoServiceProvider.Create();
            var hashedInputBytes = md5.ComputeHash(inputBytes);
            var hashedInput = Encoding.UTF8.GetString(hashedInputBytes);
            return hashedInput;
        }

        public bool IsPhoneValid(string input)
        {
            if (input.Length>5)
            {
                Regex regex = new Regex(@"[8\|+7]([0-9])*");
                var res = regex.Match(input);
                return res.Success;
            }

            return false;
        }

        public bool IsEmailValid(string input)
        {
            if (input.Length > 8)
            {
                Regex regex = new Regex(@"\w*@(\w.)+\w*");
                return regex.Match(input).Success;
            }

            return false;
        }
    }
}