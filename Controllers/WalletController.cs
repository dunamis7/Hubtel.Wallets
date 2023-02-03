using System.Threading.Tasks;
using Hubtel.Wallets.Api.Models;
using Hubtel.Wallets.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hubtel.Wallets.Api.Controllers
{
    [Route("wallets")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;

        public WalletController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }
        
        //Create a new wallet
        [HttpPost]
        public async Task<IActionResult> CreateWallet([FromBody] Wallet wallet)
        {
            //Prevent duplicate wallets
            var accountExists = await _repositoryService.CheckAccountNumber(wallet);
            if (accountExists!=null)
                return BadRequest("Account number already exists");
            
            //Checks if a user have more than 5 wallets
            var canCreateWallet =_repositoryService.NumberOfWallets(wallet.UserId);
            if (canCreateWallet == true) 
                return BadRequest("Can't create more than 5 wallets");


            //Checks if a user uses a different phone number than what he previously used 
            var phoneNumberExists = await _repositoryService.CheckPhoneNumberForSameUser(wallet);
            if (phoneNumberExists==true)
            {
                return BadRequest("Use same phone number used for previous wallets");
            }
            
            
            //Checks if a new user uses a phone number already in the database 
            var phoneNumberExist = await _repositoryService.CheckPhoneNumberForDifferentUser(wallet);
            if (phoneNumberExist==true)
            {
                return BadRequest("Phone number exists for another user");
            }
            
            
            //Add the wallet
            await _repositoryService.CreateWallet(wallet);
            return Ok($"Wallet {wallet.AccountNumber} created");
        }


        //Get all wallets for a user
        [HttpGet()]
        [Route("/users/{id:int}/wallets")]
        public async Task<IActionResult> GetWallets(int id)
        {
            //Checks if user exists
            var user = await _repositoryService.GetUser(id);
            if (user == null)
                return NotFound();
            
            var wallets = await _repositoryService.GetUserWallets(id);
            return Ok(wallets);
        }
        
        //Gets a wallet for a user
        [HttpGet()]
        [Route("/users/{userid:int}/wallets/{walletId:int}")]
        public async Task<IActionResult> GetWallet(int userid, int walletId)
        {
            //Checks if user exists
            var user = await _repositoryService.GetUser(userid);
            if (user == null)
                return NotFound();
            
            //Checks if wallet exists
            var wallet = await _repositoryService.GetWallet(walletId);
            if (wallet == null)
                return NotFound();
            

            //Checks if user owns the wallet
            if (user.UserId != wallet.UserId)
            {
                return BadRequest();
            }
 
            
            //Return found wallet
            return Ok(wallet);
        }
        
        
        //Deletes a user's wallet
        [HttpDelete()]
        [Route("/users/{userid:int}/wallets/{walletId:int}")]
        public async Task<IActionResult> DeleteWallet(int userid, int walletId)
        {
            //Checks if user exists
            var user = await _repositoryService.GetUser(userid);
            if (user == null)
                return NotFound();
            
            //Checks if wallet exists
            var wallet = await _repositoryService.GetWalletValidation(walletId);
            if (wallet == null)
                return NotFound();
            
            //Checks if user owns the wallet
            if (user.UserId != wallet.UserId)
            {
                return BadRequest();
            }

            //Deletes wallet
            await _repositoryService.DeleteWallet(wallet);
            return NoContent();
        }


        //Returns all wallets in the database
        [HttpGet]
        public async Task<IActionResult> GetAllWallets()
        {
            var wallets = await _repositoryService.GetAllWallets();
            return Ok(wallets);
        }
        
        
        //Returns a wallet in the database
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetWallet(int id)
        {
            //Checks if wallet exists
            var wallet = await _repositoryService.GetWallet(id);
            if (wallet == null)
                return NotFound();
            
            
            return Ok(wallet);
        }
        
        
        //Deletes a wallet
        [HttpDelete()]
        [Route("{walletId:int}")]
        public async Task<IActionResult> DeleteWallet(int walletId)
        {
            //Checks if wallet exists
            var wallet = await _repositoryService.GetWalletValidation(walletId);
            if (wallet == null)
                return NotFound();

            //Deletes wallet
            await _repositoryService.DeleteWallet(wallet);
            return NoContent();
        }

        
    }
}