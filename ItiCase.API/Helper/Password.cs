using System.Linq;
using System.Text.RegularExpressions;

namespace ItiCaseAPI.Helper
{
    public static class Password
    {
        public static bool IsValid(string password)
        {
            if (password.Length < 9)
            {
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                return false;
            }
            if (!password.Any(char.IsLower))
            {
                return false;
            }
            if (!password.Any(char.IsDigit))
            {
                return false;
            }
            var regexItem = new Regex("^[a-zA-Z0-9]*$");
            if (regexItem.IsMatch(password))
            {
                return false;
            }

            return true;
        }
    }
}
