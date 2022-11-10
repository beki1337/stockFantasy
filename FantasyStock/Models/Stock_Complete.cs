namespace FantasyStock.Models
{
    public class Stock_Complete
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Ticket { get; set; }
        public ICollection<Stock> stocks { get; set; }
    }
}
