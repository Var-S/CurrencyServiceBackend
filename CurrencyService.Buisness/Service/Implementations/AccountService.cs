using System.Security.Cryptography;
using System.Text;
using CurrencyService.Buisness.DTO;
using CurrencyService.Buisness.Mapping;
using CurrencyService.DataAccess;
using CurrencyService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyService.Buisness.Service.Implementations;

public sealed class AccountService : IAccountService
{
    private readonly DataBase _context;

    public AccountService(DataBase context)
    {
        _context = context;
    }

    public async Task<AccountDto> CreateAccount(string mail, string password)
    {
        ArgumentNullException.ThrowIfNull(mail, nameof(mail));
        ArgumentNullException.ThrowIfNull(password, nameof(password));

        string passwordHash = GetPasswordHash(password);

        var account = new Account(Guid.NewGuid(), mail, passwordHash);
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return account.AsDto();
    }

    public async Task<AccountDto> FindAccount(string mail, string password)
    {
        ArgumentNullException.ThrowIfNull(mail, nameof(mail));
        ArgumentNullException.ThrowIfNull(password, nameof(password));

        string passwordHash = GetPasswordHash(password);

        Account? account = (await _context.Accounts
            .FirstOrDefaultAsync(x => x.Mail == mail && x.PasswordHash == passwordHash));

        return account?.AsDto();
    }

    private static string GetPasswordHash(string password)
    {
        using var hashingAlgorithm = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        return BitConverter.ToString(hashingAlgorithm.ComputeHash(passwordBytes));
    }
}