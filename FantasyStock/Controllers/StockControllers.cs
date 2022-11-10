using Microsoft.AspNetCore.Mvc;
using FantasyStock.Models;
using FantasyStock.Dtos.Stocks;
using FantasyStock.Dtos;
using FantasyStock.Data;
using FantasyStock.Services;
using FantasyStock.Models.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace FantasyStock.Controllers
{
    [ApiController]
    [Route("stock/[controller]")]
    public class StockControllers : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IApiClinetService _apiClinetService;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockControllers(DataContext context, IApiClinetService apiClinetService,IStockRepository stockRepository, IMapper mapper)
        {
            _context = context;
            _apiClinetService = apiClinetService;
            _stockRepository = stockRepository;
            _mapper = mapper;

        }
        [HttpGet("serachStock")]
        public async Task<ActionResult<ServiceResponse<StockDto>>> GetStock(string symbol)
        {



            return Ok(await _apiClinetService.GetSymbol(symbol));

        }

        [HttpGet("getStockQouta")]

        public async Task<ActionResult<ServiceResponse<StockQuote>>> GetQuote(string symbol)
        {

            return Ok(await _apiClinetService.GetQuote(symbol));
        }

        [HttpGet("getStock")]

        public ActionResult<Stock> GetStockfromDatabase()
        {

            return Ok(_context.Users.ToList());

        }

        [HttpPost("setStock")]

        public async Task<ActionResult<ServiceResponse<Stock>>> SetStock(Stock stock)
        {
            _context.AddAsync(stock);
            return Ok(stock);
        }

        [HttpGet("seAllSrock")]
        public async Task<ActionResult<ServiceResponse<List<Stock>>>> AllStock()
            {
                var stocks = _context.Stocks.ToList();
                return Ok(stocks);
            }
        [HttpPost("set stock")]

        public async Task<ActionResult<ServiceResponse<Stock>>>  SetStock(AddStockDto request)
        {
            Stock stock = _mapper.Map<Stock>(request);

            await _context.Stocks.AddAsync(stock);

            var  serviceResponse = new ServiceResponse<Stock>();
            serviceResponse.Data = stock;

            return serviceResponse;
        }
        
        


    }
}
