using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hubtel.Wallets.Api.Models;

namespace Hubtel.Wallets.Api.Services
{
    public interface IRepositoryService
    {
        Task CreateUser(User value);

        Task<IEnumerable<User>> GetUsers();
        
        Task<User> GetUser(int id);
        
        Task CreateWallet(Wallet value);
        
        Task<IEnumerable<Wallet>> GetUserWallets(int id);
        
        
        Task<Wallet> GetWallet(int id);

        Task DeleteWallet(Wallet wallet);

        bool NumberOfWallets(int id);
        
        Task<Wallet> CheckAccountNumber(Wallet wallet);
        
        Task<IEnumerable<Wallet>> GetAllWallets();

     

    }


}