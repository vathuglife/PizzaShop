namespace DaoVietAnh.Asm2.Repo.Constants
{
    public class ValidationConstants
    {
        public static string VALID_USERNAME_REGEX = 
            "^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$";
        public static string VALID_PASSWORD_REGEX = 
            "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$";
    }
}
