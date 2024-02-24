using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services
{
    public interface IAccountService
    {
        public AccountServiceResponse Register(RegisterCredentialsDTO registerCredentials);
        public AccountServiceResponse Login(LoginCredentialsDTO loginCredentials);        
    }
}
