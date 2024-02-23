using DaoVietAnh.Asm2.Repo.Constants;
using System.Text.RegularExpressions;

namespace DaoVietAnh.Asm2.Repo.Utils
{
    public class ValidationUtils
    {
        public static bool IsUsernameValid(string username)
        {
            if (username == null) return false;
            return Regex.IsMatch(username,ValidationConstants.VALID_USERNAME_REGEX);
        }
        public static bool IsPasswordValid(string password)
        {
            if (password == null) return false;
            return Regex.IsMatch(password,ValidationConstants.VALID_PASSWORD_REGEX);
        }

    }
}
