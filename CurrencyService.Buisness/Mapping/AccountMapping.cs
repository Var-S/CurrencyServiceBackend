using CurrencyService.Buisness.DTO;
using CurrencyService.DataAccess.Models;

namespace CurrencyService.Buisness.Mapping;

public static class AccountMapping
{
    public static AccountDto AsDto(this Account account)
    {
        return new AccountDto(account.Id, account.Mail);
    }
}