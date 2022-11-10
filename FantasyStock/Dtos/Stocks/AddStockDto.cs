namespace FantasyStock.Dtos.Stocks
{
    public class AddStockDto
    {

        public string Name { get; set; }

        public string Symbol { get; set; }

        public int Volume { get; set; }

        public float Close { get; set; }

        public float Low { get; set; }

        public float High { get; set; }

        public float Open { get; set; }

        public string? Time { get; set; }
    }
}
