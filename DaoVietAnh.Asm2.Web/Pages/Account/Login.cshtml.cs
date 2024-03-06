using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.Constants.MessageResults;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using DaoVietAnh.Asm2.Repo.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DaoVietAnh.Asm2.Web.Pages.Account
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        
        public string? Username { get; set; }      
        public string? Password { get; set; }        
        public bool ShowPopup { get; set; }        
        public string? PopupMsg { get; set; }
        
        private readonly IAccountService _accountService;
        
        private Dictionary<AccountServiceEnum, Action>? _loginAccountCases;
        private AccountServiceResponse? _accountServiceResult;
        private string? _endpoint;
        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;            
            InitializeObjects();
        }

        public IActionResult OnPost()
        {
            _accountServiceResult = _accountService.Login(new LoginCredentialsDTO
            {
                Username = Username,
                Password = Password
            });
            _loginAccountCases?.First(kvp => kvp.Key == _accountServiceResult.Result)
                .Value();
            return RedirectToPage(_endpoint);
        }

        private void InitializeObjects()
        {
            _loginAccountCases = new Dictionary<AccountServiceEnum, Action>
        {
            { AccountServiceEnum.INVALID_CREDENTIALS,() => ShowInvalidLoginCredentialsPopup() } ,
            { AccountServiceEnum.SUCCESS,() => HandleSuccessfulLogin() }
        };
        }
        private void ShowInvalidLoginCredentialsPopup()
        {
            PopupMsg = LoginMessageResults.INVALID_CREDENTIALS;
            ShowPopup = true;
            _endpoint = "/Account/Login";
        }
        public void HandleSuccessfulLogin()
        {
            InitializeAccountSession();
            _endpoint = "/Index";
        }
        private void InitializeAccountSession()
        {
            HttpContext.Session.SetString("account", GetSerializedAccountDTO());
            HttpContext.Session.SetString("cart", GetSerializedCart());
        }
        private string GetSerializedAccountDTO()
        {            
            return JsonConvert.SerializeObject((AccountDTO)_accountServiceResult!.ReturnData!);            
        }
        private string GetSerializedCart()
        {
            List<PizzaDTO> cart = new List<PizzaDTO>();
            return JsonConvert.SerializeObject(cart);
        }               
    }
}
