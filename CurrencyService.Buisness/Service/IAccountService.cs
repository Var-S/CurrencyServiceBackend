using CurrencyService.Buisness.DTO;

namespace CurrencyService.Buisness.Service;

public interface IAccountService
{
    Task<AccountDto> CreateAccount(string name, string password);

    Task<AccountDto> FindAccount(string name, string password);
}