using Microsoft.AspNetCore.Mvc;
using FantasyStock.Services;
using FantasyStock.Models;
using FantasyStock.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace FantasyStock.Controllers
{

    [ApiController]
    [Route("portfolio/[controller]")]
    public class PortfolioControllers : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        public PortfolioControllers(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }


        [HttpPost("addPortfolio")]
        public async Task<ActionResult<ServiceResponse<Portfolio>>> AddPortfolio(AddPortfolioDto request)
        {


            return Ok(await _stockRepository.AddPortfolio(request));
        }


        [HttpGet("GetUser"),Authorize]

        public ActionResult<string> GetUser()
        {
            return Ok(_stockRepository.GetUser());
        }
    }
}
