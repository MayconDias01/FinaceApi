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

        // CORREÇÃO: Removido o ; que estava aqui antes do {
        public WalletRepository(FinanceDbContext context)
        {
            _context = context;
        }

        // CORREÇÃO: Removido o ; antes do {
        public async Task AddAsync(Wallet wallet, CancellationToken cancellationToken = default)
        {
            await _context.Wallets.AddAsync(wallet, cancellationToken);
        }

        // CORREÇÃO: Removido o ; e ADICIONADO { } em volta do return
        public async Task<Wallet?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Wallets
                .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
        }
    }
}