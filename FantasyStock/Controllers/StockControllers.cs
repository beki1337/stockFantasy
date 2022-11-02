using Microsoft.AspNetCore.Mvc;
using FantasyStock.Models;
using FantasyStock.Dtos.Stocks;
using FantasyStock.Data;
using FantasyStock.Services;

namespace FantasyStock.Controllers
{
    [ApiController]
    [Route("stock/[controller]")]
    public class StockControllers : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IApiClinetService _apiClinetService;

        public StockControllers(DataContext context, IApiClinetService apiClinetService)
        {
            _context = context;
            _apiClinetService = apiClinetService;
        }
        [HttpGet("serachStock")]
        public async Task<ActionResult<ServiceResponse<StockDto>>> GetStock(string symbol)
        {

            
            
            return Ok(await _apiClinetService.GetSymbol(symbol));

        }



    }
}
