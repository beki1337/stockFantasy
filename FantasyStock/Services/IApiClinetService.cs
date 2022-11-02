using FantasyStock.Models;
using FantasyStock.Dtos.Stocks;
using FantasyStock.Models.ApiClient;


namespace FantasyStock.Services
{
    public interface IApiClinetService
    {
        Task<StockDto> CallApi(string ticket);

        Task<ServiceResponse<SerachEndpoint>> GetSymbol(string symbol);
    }
}
