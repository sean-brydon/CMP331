using System.Text.RegularExpressions;

namespace CMP332.Core.Utils
{
    public class Validator
    {
        public static bool isValidPassword(string password)
        {
            
            string passwordValidator = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            Match match = Regex.Match(password, passwordValidator);
            return match.Success;
        }
    }
}