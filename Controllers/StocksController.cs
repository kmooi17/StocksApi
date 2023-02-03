using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace StocksApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StocksController : ControllerBase
{
  [HttpGet(Name = "GetAllStocks")]
  public IActionResult GetAllStocks()
  {
    string path = Path.Combine(Directory.GetCurrentDirectory(), "./Data/Stocks.json");
    string json = System.IO.File.ReadAllText(path);

    Stocks[] data = JsonConvert.DeserializeObject<Stocks[]>(json);
    return Ok(data);
  }

  [HttpGet("{id}", Name = "GetStockValues")]
  public IActionResult GetStockValues(int id)
  {
    string path = Path.Combine(Directory.GetCurrentDirectory(), "./Data/Stock Values.json");
    string json = System.IO.File.ReadAllText(path);

    StockValues[] data = JsonConvert.DeserializeObject<StockValues[]>(json);
    if (data != null)
    {
      StockValues[] result = data.Where(s => s.Stock_id == id).ToArray();
      return Ok(result);
    }

    return Ok();
  }
}
