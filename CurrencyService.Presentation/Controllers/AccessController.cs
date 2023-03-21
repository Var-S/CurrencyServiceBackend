using CurrencyService.Buisness.DTO;
using CurrencyService.Buisness.Service;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyService.Presentation.Controllers;

public class AccessController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccessController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [Route("/api/login")]
    [HttpPost]
    public async Task<IActionResult> LoginPost(string mail, string password)
    {
        AccountDto account = await _accountService.FindAccount(mail, password);
        
        if (account is null)
        {
            return Unauthorized("User is not authenticated");
        }

        return Ok(account);
    }
    
    [Route("/api/registration")]
    [HttpPost]
    public async Task<IActionResult> RegisterPost(string mail, string password)
    {
        AccountDto account = await _accountService.CreateAccount(mail, password);
        return Ok(account);
    }
}