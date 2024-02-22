using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Constants
{
    public static class RegisterMessageResults
    {
        public static string INVALID_CREDENTIALS = 
            "The username should be between 7 and 21 characters in length, and contain no spaces.\n" +
            "The password should be longer than 8 characters, contain a leading uppercase, and a special character.";
        public static string USERNAME_DUPLICATED = "The username is duplicated. Please choose another one.";
        public static string SUCCESS = "The account is successfully created.";
    }
}
