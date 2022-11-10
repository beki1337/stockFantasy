using Microsoft.EntityFrameworkCore;
using FantasyStock.Models;
using System.Linq;

using Newtonsoft.Json;
using System.Data;
using System.Data;
using FantasyStock.Models;

namespace FantasyStock.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
      
        }
       
      
        public DbSet<User> Users { get; set; }
       
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
