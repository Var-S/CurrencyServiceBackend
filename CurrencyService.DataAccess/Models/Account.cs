namespace CurrencyService.DataAccess.Models;

public class Account
{
    public Account(Guid id, string mail, string passwordHash)
    {
        Id = id;
        Mail = mail;
        PasswordHash = passwordHash;
    }

    protected Account()
    {
    }

    public Guid Id { get; set; }

    public string Mail { get; set; }

    public string PasswordHash { get; set; }
}