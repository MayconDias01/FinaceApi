using FinanceApi.Domain.Entities;
using FinanceApi.Domain.Interfaces;
using FinanceApi.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceApi.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinanceDbContext _context;

        public TransactionRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            await _context.Transactions.AddAsync(transaction, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}