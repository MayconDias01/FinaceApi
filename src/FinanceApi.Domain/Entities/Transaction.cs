using System;
using FinanceApi.Domain.Common;
using FinanceApi.Domain.Enums;
using FinanceApi.Domain.ValueObjects;

namespace FinanceApi.Domain.Entities
{
    public class Transaction : AuditableEntity
    {
        public Guid WalletId { get; private set; }
        public Guid? CategoryId { get; private set; }
        public TransactionType Type { get; private set; }
        public TransactionStatus Status { get; private set; }
        public Money Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime? DueDate { get; private set; }
        public DateTime? PaymentDate { get; private set; }

        // --- CORREÇÃO DOS AVISOS ---
        // Inicializamos com 'default!' para enganar o compilador.
        // O EF Core vai sobrescrever isso com os dados do banco depois.
        private Transaction()
        {
            Amount = default!;
            Description = default!;
        }

        public Transaction(
            Guid walletId,
            TransactionType type,
            TransactionStatus status,
            Money amount,
            string description,
            DateTime? dueDate,
            DateTime? paymentDate,
            Guid? categoryId = null)
        {
            if (amount.Amount <= 0)
                throw new InvalidOperationException("Transaction amount must be greater than zero.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description));

            WalletId = walletId;
            Type = type;
            Status = status;
            Amount = amount;
            Description = description;
            DueDate = dueDate;
            PaymentDate = paymentDate;
            CategoryId = categoryId;
        }

        public void MarkAsPaid(DateTime paymentDate)
        {
            // --- CORREÇÃO DO ERRO ---
            // Seu Enum chama 'Completed', não 'Paid'
            Status = TransactionStatus.Completed;
            PaymentDate = paymentDate;
        }
    }
}