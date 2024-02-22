﻿using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services
{
    public interface IAccountService
    {
        public AccountServiceResult Register(RegisterCredentialsDTO registerCredentials);
        public AccountServiceResult Login(LoginCredentialsDTO loginCredentials);
        public AccountServiceResult Logout();
    }
}