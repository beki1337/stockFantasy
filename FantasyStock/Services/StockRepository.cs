using FantasyStock.Models;
using FantasyStock.Dtos.Stocks;
using FantasyStock.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace FantasyStock.Services
{
    [ApiController]
    public class StockRepository : IStockRepository
    {


        private readonly DataContext _context;
        private readonly IApiClinetService _apiClinetService;
        
        public StockRepository(DataContext context, IApiClinetService apiClinetService)
        {
            _context = context;
            _apiClinetService = apiClinetService;


        }

       
        


    }
}
