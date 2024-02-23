﻿using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private RegisterService? _registerService;
        private LoginService? _loginService;
        public AccountService()
        {
            InitializeObjects();
        }
        public AccountServiceResult Register(RegisterCredentialsDTO registerCredentials)
        {
            return _registerService!.CreateNewAccount(registerCredentials);
        }
        public AccountServiceResult Login(LoginCredentialsDTO loginCredentials)
        {
            return _loginService!.Login(loginCredentials);
        }

        private void InitializeObjects()
        {
            _registerService = new RegisterService();
            _loginService = new LoginService();
        }      
    }
}
