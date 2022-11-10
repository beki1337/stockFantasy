using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyStock.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Symbol { get; set; }  

        public int Volume { get; set; } 

        public float Close { get; set; }

        public float Low { get; set; }

        public float High { get; set; }

        public float Open { get; set; }   

        public string? Time { get; set; }



    }
}
