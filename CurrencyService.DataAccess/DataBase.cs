using CurrencyService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyService.DataAccess;

public sealed class DataBase : DbContext
{
    public DataBase(DbContextOptions<DataBase> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Account> Accounts => Set<Account>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Accounts.db");
    }
}