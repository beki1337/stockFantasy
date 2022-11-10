namespace FantasyStock.Models
{
    public class StockBounght
    {
        public int Id { get; set; }
        public double price { get; set; }

        public Stock_Complete stock { get; set; }
        public DateTime DateBought { get; set; }
    }
}
