using DaoVietAnh.Asm2.Repo.Constants;
using DaoVietAnh.Asm2.Repo.Results;
using DaoVietAnh.Asm2.Repo.Services;
using DaoVietAnh.Asm2.Repo.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DaoVietAnh.Asm2.Web.Pages.Account
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        [Required]
        public string? Username { get; set; }

        [BindProperty]
        [Required]
        public string? Password { get; set; }

        [BindProperty]
        public bool ShowPopup { get; set; }

        [BindProperty]
        public string? PopupMsg { get; set; }
        private readonly IAccountService _accountService;
        private Dictionary<AccountServiceResult, Action>? _loginAccountCases;
        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
            InitializeObjects();
        }

        public IActionResult OnPost()
        {
            var result = _accountService.Login(new Repo.DTO.LoginCredentialsDTO
            {
                Username = Username,
                Password = Password
            });
            _loginAccountCases?.First(kvp => kvp.Key == result).Value();
            return Redirect("/Index");
        }

        private void InitializeObjects()
        {
            _loginAccountCases = new Dictionary<AccountServiceResult, Action>
        {
            { AccountServiceResult.INVALID_CREDENTIALS,() => ShowInvalidLoginCredentialsPopup() } ,
            { AccountServiceResult.SUCCESS,() => HandleSuccessfulLogin() }
        };
        }
        private void ShowInvalidLoginCredentialsPopup()
        {
            PopupMsg = LoginMessageResults.INVALID_CREDENTIALS;
            ShowPopup = true;
        }
        public void HandleSuccessfulLogin()
        {
            HttpContext.Session.SetString("user", Username!);

        }
    }
}
