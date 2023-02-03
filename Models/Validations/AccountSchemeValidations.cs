using System.ComponentModel.DataAnnotations;
using Hubtel.Wallets.Api.Models.Enums;

namespace Hubtel.Wallets.Api.Models.Validations
{
    public class AccountSchemeValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var account = validationContext.ObjectInstance as Wallet;

            if (account.Type == Account.Momo.ToString())
            {
                
                if (
                    account.AccountSchemeType != AccountScheme.Vodafone.ToString() && 
                    account.AccountSchemeType != AccountScheme.Airteltigo.ToString() &&
                    account.AccountSchemeType != AccountScheme.Mtn.ToString()
                )
                {
                    return new ValidationResult("Momo users must chose either Mtn, Vodafone or Airteltigo");
                }
            }
            
            if (account.Type == Account.Card.ToString())
            {
                if (account.AccountSchemeType != AccountScheme.Visa.ToString()
                    && account.AccountSchemeType != AccountScheme.Mastercard.ToString())
                {
                    return new ValidationResult("Bank card holders should use their Visa or Mastercard");
                }
            }
            return ValidationResult.Success;
        }
    }
}