using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace CurrencyService.Buisness.Service.Implementations;

public class CurrencyService
{
    public string GetQuote(string day, string month, string year)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var urlString = "https://www.cbr.ru/scripts/XML_daily.asp?date_req=" + day + "/" + month + "/" + year;
        XDocument xml = XDocument.Load(urlString);
        var json = JsonConvert.SerializeObject(xml, Formatting.Indented);
        return json;
    }
}