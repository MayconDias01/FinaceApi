using FinanceApi.Domain.Entities;
using FinanceApi.Domain.Enums; // Para TransactionType e TransactionStatus
using FinanceApi.Domain.Interfaces;
using FinanceApi.Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceApi.Application.UseCases.Transactions.CreateTransaction
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransactionHandler(IWalletRepository walletRepository, ITransactionRepository transactionRepository)
        {
            _walletRepository = walletRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            // 1. Busca a Carteira
            var wallet = await _walletRepository.GetByIdAsync(request.WalletId, cancellationToken);

            if (wallet == null)
                throw new Exception("Carteira não encontrada."); // Idealmente use uma DomainException

            // 2. Prepara os dados (Value Objects)
            var amount = new Money(request.Amount, wallet.Balance.Currency);

            // 3. Aplica a Regra de Negócio na Carteira (Atualiza Saldo)
            // Se for Credit (1) -> Aumenta o saldo
            // Se for Debit (2) -> Diminui o saldo
            if (request.Type == TransactionType.Credit)
            {
                wallet.Credit(amount);
            }
            else
            {
                wallet.Debit(amount);
            }

            // 4. Cria a Transação (Respeitando a ordem EXATA do construtor que apareceu no erro)
            // Ordem: (Guid walletId, TransactionType type, TransactionStatus status, Money amount, string description, DateTime? date, DateTime? updatedAt, Guid? categoryId)
            var transaction = new Transaction(
                request.WalletId,                        // 1. WalletId
                request.Type,                            // 2. Type (Credit/Debit)
                TransactionStatus.Completed,             // 3. Status (Assumindo Completed ao nascer)
                amount,                                  // 4. Amount (Value Object)
                "Transação via API",                     // 5. Description
                DateTime.UtcNow,                         // 6. Date
                null,                                    // 7. UpdatedAt
                null                                     // 8. CategoryId
            );

            // 5. Salva Tudo
            await _transactionRepository.AddAsync(transaction, cancellationToken);
            await _walletRepository.UpdateAsync(wallet, cancellationToken); // Salva o novo saldo da carteira

            return transaction.Id;
        }
    }
}