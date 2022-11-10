using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyStock.Models
{
    public class Portfolio
    {
        [ForeignKey("User")]
        public int PortfolioId { get; set; }

        public double Available_funds { get; set; } = 1000000.00;

        public double Total_balance { get; set; } = 1000000.00;
        public string Name { get; set; }    
       
        public ICollection<StockBounght> stocks { get; set; }
        public User User { get; set; }


    }
}
