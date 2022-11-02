using FantasyStock.Models;
using FantasyStock.Dtos.Stocks;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FantasyStock.Data;

using FantasyStock.Models.ApiClient;

namespace FantasyStock.Services
{
    public class ApiClientService: IApiClinetService
    {


        private readonly DataContext _context;

        public ApiClientService(DataContext context)
        {
            _context = context;
        }
        static string GetUrl(string funktion, string symbol, string interval)
        {

            string url = string.Format("https://www.alphavantage.co/query?function={0}&symbol={1}&interval={2}&apikey=Z4CT93FXJDPZHGNU", funktion, symbol, interval);
            return url;

        }
        static string GetUrl(string funktion, string keyword)
        {
            string url = String.Format("https://www.alphavantage.co/query?function={0}&keywords={1}&apikey=Z4CT93FXJDPZHGNU", funktion, keyword);
            return url;
        }


        public async Task<StockDto> CallApi(string ticket)
        {
            StockDto result = null;
            string url = GetUrl("TIME_SERIES_INTRADAY", ticket, "5min");
            HttpRequest<StockDto> SerachStock = new HttpRequest<StockDto>();
            result = await SerachStock.ApiCall(url);

            return result;

        }


        public async Task<ServiceResponse<SerachEndpoint>> GetSymbol(string symbol)
        {

            var searchQuary = await _context.SerachEndpoint.FirstOrDefaultAsync(c)
            var serviceResponse = new ServiceResponse<SerachEndpoint> ();
            SerachEndpoint result = null;
            string url = GetUrl("SYMBOL_SEARCH", symbol);
            HttpRequest<SerachEndpoint> SerachStock = new HttpRequest<SerachEndpoint>();
            result =  await  SerachStock.ApiCall(url);
            serviceResponse.Data = result;
            return serviceResponse;
        }

      
    }


    public class HttpRequest<T>
    {
        static HttpClient client = new HttpClient();
        public  async Task<T> ApiCall(string url)
        {
            T source = default(T);
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                source = System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            return source;
        }


        static string GetUrl(string funktion, string symbol, string interval)
        {

            string url = string.Format("https://www.alphavantage.co/query?function={0}&symbol={1}&interval={2}&apikey=Z4CT93FXJDPZHGNU", funktion, symbol, interval);
            return url;

        }
        static string GetUrl(string funktion, string keyword)
        {
            string url = String.Format("https://www.alphavantage.co/query?function={0}&keywords={1}&apikey=Z4CT93FXJDPZHGNU", funktion, keyword);
            return url;
        }

    }

}
