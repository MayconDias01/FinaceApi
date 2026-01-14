namespace FinanceApi.Domain.Entities;

public class ReceivableAccount : Account
{
    /// <summary>
    /// Customer name
    /// Nome do cliente
    /// </summary>
    public string Customer { get; private set; } = string.Empty;

    protected ReceivableAccount() { }

    /// <summary>
    /// Creates a new receivable account
    /// Cria uma nova conta a receber
    /// </summary>
    public ReceivableAccount(
        string description,
        decimal amount,
        DateTime dueDate,
        string customer)
    {
        Id = Guid.NewGuid();
        Description = description;
        Amount = amount;
        DueDate = dueDate;
        Customer = customer;
        IsPaid = false;
    }
}
