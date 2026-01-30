using System;
using System.Threading;
using System.Threading.Tasks;
using FinanceApi.Domain.Entities;

namespace FinanceApi.Domain.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Wallet wallet, CancellationToken cancellationToken = default);
    }
}