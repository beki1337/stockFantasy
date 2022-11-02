using Microsoft.EntityFrameworkCore;
using FantasyStock.Models;
using FantasyStock.Models.ApiClient;

namespace FantasyStock.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<SerachEndpoint> SerachEndpoints { get; set; }
    }
}
