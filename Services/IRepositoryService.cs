using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hubtel.Wallets.Api.DTOs;
using Hubtel.Wallets.Api.Models;

namespace Hubtel.Wallets.Api.Services
{
    public interface IRepositoryService
    {
        Task CreateUser(User value);

        Task<IEnumerable<UserDto>> GetUsers();
        
        Task<UserDto> GetUser(int id);
        
        Task CreateWallet(Wallet value);
        
        Task<IEnumerable<WalletDto>> GetUserWallets(int id);
        
        
        Task<WalletDto> GetWallet(int id);

        Task DeleteWallet(Wallet wallet);

        bool NumberOfWallets(int id);
        
        Task<Wallet> CheckAccountNumber(Wallet wallet);
        
        Task<IEnumerable<WalletDto>> GetAllWallets();


        Task<User> GetUserValidation(int id);

        Task<Wallet> GetWalletValidation(int walletId);
        
        Task<bool> CheckPhoneNumberForSameUser(Wallet wallet);
        
        Task<bool> CheckPhoneNumberForDifferentUser(Wallet wallet);

        
    }


}