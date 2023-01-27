using System.ComponentModel.DataAnnotations;
using Hubtel.Wallets.Api.Models.Enums;

namespace Hubtel.Wallets.Api.Models.Validations
{
    public class AccountNumberValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var account = validationContext.ObjectInstance as Wallet;

            if (account.Type == Account.Card.ToString())
            {
                if (account.AccountNumber.Length > 6)
                {
                    var truncatedAccountNumber = account.AccountNumber.Substring(0, 6);
                    validationContext.ObjectType.GetProperty(validationContext.MemberName)
                        ?.SetValue(validationContext
                            .ObjectInstance,truncatedAccountNumber);
                }
               
            }

            if (account.Type == Account.Momo.ToString())
            {
                if (account.AccountNumber.Length < 10)
                {
                    return new ValidationResult("Enter a valid phone number, at least 10 digits");
                }
               
            }
            
            return ValidationResult.Success;
        }
    }
}