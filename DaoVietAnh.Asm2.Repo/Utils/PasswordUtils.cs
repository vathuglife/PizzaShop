
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Utils
{
    public static class PasswordUtils
    {
        public static string GetHashedPwd(string rawPwd)
        {
            return BCrypt.Net.BCrypt.HashPassword(rawPwd);
        }
        public static bool VerifyPwd(string rawPwd,string hashedPwd)
        {
            return BCrypt.Net.BCrypt.Verify(rawPwd, hashedPwd);
        }
    }
}
