using AutoMapper;
using FantasyStock.Models;
using FantasyStock.Dtos;
using FantasyStock.Dtos.Stocks;

namespace FantasyStock
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Portfolio, AddPortfolioDto>();
            CreateMap<AddPortfolioDto,Portfolio>();
            CreateMap<Stock, AddStockDto>();
            CreateMap<AddStockDto,Stock>();

        }
    }
}
