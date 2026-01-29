using System;

namespace FinanceApi.Domain.ValueObjects
{
    // MUDEI DE 'record struct' PARA 'record class'
    public record class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency cannot be empty.", nameof(currency));

            Amount = amount;
            Currency = currency.ToUpper();
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new ArgumentException($"Cannot add different currencies: {a.Currency} and {b.Currency}");

            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new ArgumentException($"Cannot subtract different currencies: {a.Currency} and {b.Currency}");

            if (a.Amount < b.Amount)
                throw new ArgumentException("Resulting amount cannot be negative.");

            return new Money(a.Amount - b.Amount, a.Currency);
        }

        public static Money Zero(string currency) => new Money(0, currency);
    }
}












