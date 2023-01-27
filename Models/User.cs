using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Hubtel.Wallets.Api.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }    
        
        [Required]
        public string Name { get; set; }  
        
        [JsonIgnore]
        public ICollection<Wallet> Wallets { get; set; }
    }
}