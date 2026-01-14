using FinanceApi.Domain.Common;

namespace FinanceApi.Domain.Entities;

public abstract class Account : AuditableEntity
{
	
	/// Unique identifier of the account
	/// Identificador único da conta
	public Guid Id { get; protected set; }

	
	/// Account description
	/// Descrição da conta
	public string Description { get; protected set; } = string.Empty;

	
	/// Account amount
	/// Valor da conta
	public decimal Amount { get; protected set; }

	
	/// Due date of the account
	/// Data de vencimento da conta
	public DateTime DueDate { get; protected set; }

	
	/// Indicates whether the account is paid
	/// Indica se a conta está paga
	public bool IsPaid { get; protected set; }

	protected Account()
	{
		IsPaid = false;
	}

	
	/// Marks the account as paid
	/// Marca a conta como paga
	public void MarkAsPaid()
	{
		if (IsPaid)
			return;

		IsPaid = true;
	}
}
