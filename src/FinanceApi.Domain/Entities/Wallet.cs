using System;
using FinanceApi.Domain.Common;
using FinanceApi.Domain.ValueObjects;

namespace FinanceApi.Domain.Entities
{
    public class Wallet : AuditableEntity
    {
        public Money Balance { get; private set; }

        private Wallet() { }

        public Wallet(string currency)
        {
            Balance = Money.Zero(currency);
        }

        public void Debit(Money amount)
        {
            if (Balance.Currency != amount.Currency)
                throw new InvalidOperationException("Currency mismatch.");

            if (amount.Amount > Balance.Amount)
                throw new InvalidOperationException("Insufficient funds.");

            Balance -= amount;
        }

        public void Credit(Money amount)
        {
            if (Balance.Currency != amount.Currency)
                throw new InvalidOperationException("Currency mismatch.");

            Balance += amount;
        }
    }
}