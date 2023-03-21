namespace CurrencyService.Buisness.Service;

public interface ICurrencyService
{
    string GetQuote(string day, string month, string year);
}