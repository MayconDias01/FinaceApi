namespace FinanceApi.Domain.Entities;

public class PayableAccount : Account
{

    /// Supplier name
    /// Nome do fornecedor
    public string Supplier { get; private set; } = string.Empty;

    protected PayableAccount() { }

    /// Creates a new payable account
    /// Cria uma nova conta a pagar
    public PayableAccount(
        string description,
        decimal amount,
        DateTime dueDate,
        string supplier)
    {
        Id = Guid.NewGuid();
        Description = description;
        Amount = amount;
        DueDate = dueDate;
        Supplier = supplier;
        IsPaid = false;
    }
}
