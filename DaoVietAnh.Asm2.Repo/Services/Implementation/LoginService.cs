using AutoMapper;
using DaoVietAnh.Asm2.Repo.Constants;
using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Entities.Results;
using DaoVietAnh.Asm2.Repo.Mappers;
using DaoVietAnh.Asm2.Repo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation
{
    public class LoginService
    {
        private LoginCredentialsDTO? _loginCredentials;
        private UnitOfWork? _unitOfWork;
        private Account? _account;
        private AccountDTO? _accountDTO;
        private Mapper? _mapper;
        
        public LoginService()
        {
            InitializeObjects();
        }
        
        public AccountServiceResult Login(LoginCredentialsDTO loginCredentials)
        {
            _loginCredentials = loginCredentials;
            GetAccountByUsername();
            if (_account == null || !IsPasswordValid())
                return GetInvalidCredentialsServiceResult();
            MapAccountToAccountDTO();
            return GetSuccessServiceResult();
        }
        private void InitializeObjects()
        {
            _unitOfWork = new UnitOfWork();
            _mapper = new Mapper(AccountMapper.AccountToAcountDTOMap());
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
        private void MapAccountToAccountDTO()
        {
            _accountDTO = _mapper?.Map<AccountDTO>(_account);
        }
        private AccountServiceResult GetInvalidCredentialsServiceResult()
        {

            return new AccountServiceResult()
            {
                Result = AccountServiceEnum.INVALID_CREDENTIALS,
                Message = LoginMessageResults.INVALID_CREDENTIALS
            };
        }
        
        private AccountServiceResult GetSuccessServiceResult()
        {
            return new AccountServiceResult()
            {
                Result = AccountServiceEnum.SUCCESS,
                Message = LoginMessageResults.SUCCESS,
                ReturnData = _accountDTO
                
            };
        }
    }
}
