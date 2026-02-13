using MediatR;
using System;
using FinanceApi.Domain.Enums; 

namespace FinanceApi.Application.UseCases.Transactions.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<Guid>
    {
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; } 
    }
}