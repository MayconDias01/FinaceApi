using FinanceApi.Domain.Common;

namespace FinanceApi.Domain.Entities;

public class CashRegister : AuditableEntity
{
    /// <summary>
    /// Unique identifier of the cash register
    /// Identificador único do caixa
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Current balance
    /// Saldo atual
    /// </summary>
    public decimal CurrentBalance { get; private set; }

    /// <summary>
    /// Last movement date and time in UTC
    /// Data e hora da última movimentação em UTC
    /// </summary>
    public DateTime? LastMovementAtUtc { get; private set; }

    /// <summary>
    /// Last movement date and time in Brazil local time
    /// Data e hora da última movimentação no horário do Brasil
    /// </summary>
    public DateTime? LastMovementAtLocal { get; private set; }

    protected CashRegister() { }

    /// <summary>
    /// Creates a new cash register
    /// Cria um novo caixa
    /// </summary>
    public CashRegister(decimal initialBalance)
    {
        Id = Guid.NewGuid();
        CurrentBalance = initialBalance;
    }

    /// <summary>
    /// Registers an income (money entry)
    /// Registra uma entrada de dinheiro
    /// </summary>
    public void RegisterIncome(decimal amount, DateTime utcNow, DateTime localNow)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Income amount must be greater than zero.");

        CurrentBalance += amount;
        SetLastMovement(utcNow, localNow);
    }

    /// <summary>
    /// Registers an expense (money exit)
    /// Registra uma saída de dinheiro
    /// </summary>
    public void RegisterExpense(decimal amount, DateTime utcNow, DateTime localNow)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Expense amount must be greater than zero.");

        if (amount > CurrentBalance)
            throw new InvalidOperationException("Insufficient balance.");

        CurrentBalance -= amount;
        SetLastMovement(utcNow, localNow);
    }

    private void SetLastMovement(DateTime utcNow, DateTime localNow)
    {
        LastMovementAtUtc = utcNow;
        LastMovementAtLocal = localNow;
    }
}
