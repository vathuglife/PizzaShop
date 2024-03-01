using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.AccountServiceImpl
{
    public class AccountService : IAccountService
    {
        private RegisterService? _registerService;
        private LoginService? _loginService;
        private IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeObjects();
        }
        public AccountServiceResponse Register(RegisterCredentialsDTO registerCredentials)
        {
            return _registerService!.CreateNewAccount(registerCredentials);
        }
        public AccountServiceResponse Login(LoginCredentialsDTO loginCredentials)
        {
            return _loginService!.Login(loginCredentials);
        }

        private void InitializeObjects()
        {
            _registerService = new RegisterService(_unitOfWork);
            _loginService = new LoginService(_unitOfWork);
        }
    }
}
