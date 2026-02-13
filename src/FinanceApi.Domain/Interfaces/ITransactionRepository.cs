using FinanceApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default);
    }
}