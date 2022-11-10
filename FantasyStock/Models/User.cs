using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyStock.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public int? Age {get; set; }
        public virtual Portfolio Portfolio { get; set; }
    }
}
