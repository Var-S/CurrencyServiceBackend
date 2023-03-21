using Microsoft.AspNetCore.Mvc;

namespace CurrencyService.Presentation.Controllers;

public class DataController : Controller
{
    private readonly Buisness.Service.Implementations.CurrencyService _currencyService = new();

    [Route("/api/quotation/{day}-{month}-{year}")]
    [HttpGet]
    public IActionResult Get([FromRoute] string day, [FromRoute] string month, [FromRoute] string year)
    {
        if (_currencyService.GetQuote(day, month, year).Contains("Error in parameters"))
        {
            return NotFound();
        }

        return Ok(_currencyService.GetQuote(day, month, year));
    }
}