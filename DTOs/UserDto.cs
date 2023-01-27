using System.ComponentModel.DataAnnotations;

namespace Hubtel.Wallets.Api.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }  
        public string Name { get; set; }
    }
}