using System;
using System.ComponentModel.DataAnnotations;
using Hubtel.Wallets.Api.Models.Enums;
using Hubtel.Wallets.Api.Models.Validations;
using Newtonsoft.Json;


namespace Hubtel.Wallets.Api.Models
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }
        
        [Required]
        [EnumDataType(typeof(Account))]
        public string Type { get; set; }
        
        [Required]
        [MinLength(6, ErrorMessage = "Minimum length of Account number should be 6")]
        [AccountNumberValidations]
        public string AccountNumber { get; set; }
        
        [Required]
        [AccountSchemeValidations]
        [EnumDataType(typeof(AccountScheme))]
        public string AccountSchemeType { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Required]
        public string PhoneNumber { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
    }


}