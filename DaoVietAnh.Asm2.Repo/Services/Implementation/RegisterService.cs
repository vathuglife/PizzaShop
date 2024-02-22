using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Mappers;
using DaoVietAnh.Asm2.Repo.Results;
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
                return AccountServiceResult.INVALID_CREDENTIALS;
            if (IsUsernameDuplicated())
                return AccountServiceResult.USERNAME_DUPLICATED;
            MapRegisterCredentialsToAccount();
            AddNewAccountToDatabase();
            return AccountServiceResult.SUCCESS;
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
            _account = _accountMapper?.Map<Account>(_registerCredentials);
            _account!.Password = PasswordUtils.GetHashedPwd(_registerCredentials?.Password!);
            _account!.Type = "0";
        }
        private void AddNewAccountToDatabase()
        {
            _unitOfWork?.AccountRepository!.Insert(_account!);
            _unitOfWork?.Save();
        }

    }

}
