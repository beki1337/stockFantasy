using FantasyStock.Models;
using FantasyStock.Dtos;
using FantasyStock.Dtos.Stocks;

namespace FantasyStock.Services
{
    public interface IStockRepository
    {

        Task<ServiceResponse<Portfolio>> AddPortfolio(AddPortfolioDto newPortfolio);

        ServiceResponse<int> GetUser();

    }
}
