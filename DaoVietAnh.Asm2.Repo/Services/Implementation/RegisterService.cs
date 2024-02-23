using DaoVietAnh.Asm2.Repo.Constants;
using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Entities.Results;
using DaoVietAnh.Asm2.Repo.Mappers;
using DaoVietAnh.Asm2.Repo.Utils;


namespace DaoVietAnh.Asm2.Repo.Services.Implementation
{
    public class RegisterService 
    {
        private RegisterCredentialsDTO? _registerCredentials;
        private Account? _account;
        private AutoMapper.Mapper? _accountMapper;
        private UnitOfWork? _unitOfWork;
        public RegisterService()
        {
            InitializeObjects();
        }
        public AccountServiceResult CreateNewAccount(RegisterCredentialsDTO registerCredentials)
        {
            _registerCredentials = registerCredentials;
            if (!AreRegisterCredentialsValid())
                return GetInvalidCredentialsServiceResult();
            if (IsUsernameDuplicated())
                return GetUsernameDuplicatedServiceResult();
            MapRegisterCredentialsToAccount();
            AddNewAccountToDatabase();
            return GetSuccessServiceResult();
        }


        private void InitializeObjects()
        {
            _unitOfWork = new UnitOfWork();
            _accountMapper =
                new AutoMapper.Mapper(AccountMapper.RegisterCredentialsToAccountMap());
        }
        private bool AreRegisterCredentialsValid()
        {
             if (!ValidationUtils.IsUsernameValid(_registerCredentials!.Username!) ||
                !ValidationUtils.IsPasswordValid(_registerCredentials.Password!))
                return false;

            return true;
        }
        private bool IsUsernameDuplicated()
        {
            var account = _unitOfWork?.AccountRepository!
                .Get(account =>
                    account.UserName!.Equals(_registerCredentials!.Username))
                .FirstOrDefault();
            if (account == null) return false;
            return true;
        }
        private void MapRegisterCredentialsToAccount()
        {
            int accountId = GetLatestAccountId();
            _account = _accountMapper?.Map<Account>(_registerCredentials);
            _account!.Password = PasswordUtils.GetHashedPwd(_registerCredentials?.Password!);
            _account!.Type = "0";
            _account.AccountId = accountId;
            
        }
        private void AddNewAccountToDatabase()
        {            
            _unitOfWork?.AccountRepository!.Insert(_account!);
            _unitOfWork?.Save();
        }
        private int GetLatestAccountId()
        {
            Account latestAccount = _unitOfWork?.AccountRepository?
                .Get()
                .OrderByDescending(account => account.AccountId)
                .FirstOrDefault()!;
            if(latestAccount==null) return 0;
            int latestAccountId = latestAccount.AccountId + 1;
            return latestAccountId;
        }
        private AccountServiceResult GetInvalidCredentialsServiceResult()
        {

            return new AccountServiceResult()
            {
                Result = AccountServiceEnum.INVALID_CREDENTIALS,
                Message = LoginMessageResults.INVALID_CREDENTIALS
            };
        }
        private AccountServiceResult GetUsernameDuplicatedServiceResult()
        {

            return new AccountServiceResult()
            {
                Result = AccountServiceEnum.USERNAME_DUPLICATED,
                Message = RegisterMessageResults.USERNAME_DUPLICATED
            };
        }
        private AccountServiceResult GetSuccessServiceResult()
        {
            return new AccountServiceResult()
            {
                Result = AccountServiceEnum.SUCCESS,
                Message = RegisterMessageResults.SUCCESS,                
            };
        }

    }

}
