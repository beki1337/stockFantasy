using FantasyStock.Models;
using FantasyStock.Dtos;
using FantasyStock.Dtos.Stocks;
using FantasyStock.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Security.Claims;

namespace FantasyStock.Services
{
    
    public class StockRepository : IStockRepository
    {


        private readonly DataContext _context;
        private readonly IApiClinetService _apiClinetService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StockRepository(DataContext context, IApiClinetService apiClinetService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _apiClinetService = apiClinetService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<Portfolio>> AddPortfolio(AddPortfolioDto newPortfolio)
       {
            var myPortfolio = await _context.Portfolios.SingleOrDefaultAsync(c => c.PortfolioId == 1);

            if (myPortfolio == null)
            {
                var serviceResponse = new ServiceResponse<Portfolio>();

                Portfolio portfolio = _mapper.Map<Portfolio>(newPortfolio);


                User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == 1);

                portfolio.User = user;




                _context.Portfolios.Add(portfolio);
                await _context.SaveChangesAsync();
                user.Portfolio = portfolio;

                serviceResponse.Data = portfolio;

                return serviceResponse;
            }
            else
            {
                var serviceResponse = new ServiceResponse<Portfolio>();
                serviceResponse.Data = myPortfolio;
                return serviceResponse;
            }
        }




        public ServiceResponse<int> GetUser()
        {

            int userId = GetUserId();

            var serviceResponse = new ServiceResponse<int>();
            serviceResponse.Data = userId;
            return serviceResponse;
        }






    }
}
