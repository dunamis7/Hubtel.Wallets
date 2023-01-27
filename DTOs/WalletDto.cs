using System;
using System.ComponentModel.DataAnnotations;
using Hubtel.Wallets.Api.Models.Enums;
using Hubtel.Wallets.Api.Models.Validations;

namespace Hubtel.Wallets.Api.DTOs
{
    public class WalletDto
    {
        public int WalletId { get; set; }
    
        public string Type { get; set; }
        

        public string AccountNumber { get; set; }
        

        public string AccountSchemeType { get; set; }

        
        public string PhoneNumber { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public int UserId { get; set; }
    }
}