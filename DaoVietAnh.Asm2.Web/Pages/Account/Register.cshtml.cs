using DaoVietAnh.Asm2.Repo.Constants;
using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Services;
using DaoVietAnh.Asm2.Repo.Utils;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Diagnostics;

namespace DaoVietAnh.Asm2.Web.Pages.Account;

public class RegisterModel : PageModel
{
    [BindProperty]
    public string? Name { get; set; }
    [BindProperty]
    public string? Username { get; set; }
    [BindProperty]
    public string? Password { get; set; }
    [BindProperty]
    public bool ShowPopup { get; set; }
    [BindProperty]
    public string? PopupMsg { get; set; }


    private readonly IAccountService _accountService;
    private Dictionary<AccountServiceEnum, Action>? _registerAccountCases;
    public RegisterModel(IAccountService accountService)
    {
        _accountService = accountService;
        InitializeObjects();

    }
    public void OnPost()
    {
        var accountServiceResult =
        _accountService.Register(new RegisterCredentialsDTO
        {
            Name = Name,
            Password = Password,
            Username = Username
        });
        _registerAccountCases?.First(kvp => kvp.Key == accountServiceResult.Result).Value();
    }
    private void InitializeObjects()
    {
        _registerAccountCases = new Dictionary<AccountServiceEnum, Action>
        {
            { AccountServiceEnum.INVALID_CREDENTIALS,() => ShowInvalidRegisterCredentialsPopup() } ,
            { AccountServiceEnum.USERNAME_DUPLICATED,() => ShowUsernameDuplicatedPopup() } ,
            { AccountServiceEnum.SUCCESS,() => ShowSuccessfulRegisterPopup() }
        };
    }
    private void ShowInvalidRegisterCredentialsPopup()
    {
        PopupMsg = RegisterMessageResults.INVALID_CREDENTIALS;
        ShowPopup = true;
    }
    private void ShowUsernameDuplicatedPopup()
    {
        PopupMsg = RegisterMessageResults.USERNAME_DUPLICATED;
        ShowPopup = true;
    }
    private IActionResult ShowSuccessfulRegisterPopup()
    {
        PopupMsg = RegisterMessageResults.SUCCESS;
        ShowPopup = true;
        return Redirect("/Account/Login");
    }
}
