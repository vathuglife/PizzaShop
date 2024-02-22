using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Mappers;
using DaoVietAnh.Asm2.Repo.Results;
using DaoVietAnh.Asm2.Repo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation
{
    public class LoginService
    {
        private LoginCredentialsDTO? _loginCredentials;
        private UnitOfWork? _unitOfWork;
        private Account? _account;
        public LoginService()
        {
            InitializeObjects();
        }
        public AccountServiceResult Login(LoginCredentialsDTO loginCredentials)
        {
            _loginCredentials = loginCredentials;
            GetAccountByUsername();
            if (_account == null || !IsPasswordValid())
                return AccountServiceResult.INVALID_CREDENTIALS;            
            return AccountServiceResult.SUCCESS;
        }
        private void InitializeObjects()
        {
            _unitOfWork = new UnitOfWork();
        }
        private void GetAccountByUsername()
        {
            _account = _unitOfWork?.AccountRepository?
                .Get(acc => acc.UserName!.Equals(_loginCredentials!.Username))
                .FirstOrDefault()!;
        }
        private bool IsPasswordValid()
        {
            if (PasswordUtils.VerifyPwd(
                _loginCredentials?.Password!,
                _account?.Password!)                
            )
                return true;
            return false;
        }

    }
}
