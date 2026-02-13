using System;
using System.Threading;
using System.Threading.Tasks;
using FinanceApi.Domain.Entities;
using FinanceApi.Domain.Interfaces;
using FinanceApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly FinanceDbContext _context;

        public WalletRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Wallet wallet, CancellationToken cancellationToken = default)
        {
            await _context.Wallets.AddAsync(wallet, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Wallet?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Wallets
                .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Wallet wallet, CancellationToken cancellationToken = default)
        {
            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}