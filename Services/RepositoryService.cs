using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hubtel.Wallets.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.Wallets.Api.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly DataContext _context;

        public RepositoryService(DataContext context)
        {
            _context = context;
        }
        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.UserId==id);
            return user;
        }

        public async Task CreateWallet(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Wallet>> GetUserWallets(int id)
        {
            var wallets = await _context.Wallets.Where(u=>u.UserId==id).ToListAsync();
            return wallets;

        }

        public async Task<Wallet> GetWallet(int walletId)
        {
            var wallet = await _context.Wallets.FirstOrDefaultAsync(w=>w.WalletId==walletId);
            return wallet;
        }

        public  async Task DeleteWallet(Wallet wallet)
        {
            _context.Wallets.Remove(wallet);
            await _context.SaveChangesAsync();
        }

        public bool NumberOfWallets(int id)
        {
            var numberOfWallets = _context.Wallets.Count(u => u.UserId == id);
            if (numberOfWallets > 4)
                return true;
            
            return false;

        }

        public async Task<Wallet> CheckAccountNumber(Wallet wallet)
        {
            var accountPresent =
                await _context.Wallets.FirstOrDefaultAsync(u=>u.AccountNumber==wallet.AccountNumber);
            return accountPresent;
        }

        public async Task<IEnumerable<Wallet>> GetAllWallets()
        {
            var wallets = await _context.Wallets.ToListAsync();
            return wallets;
        }



    }
}