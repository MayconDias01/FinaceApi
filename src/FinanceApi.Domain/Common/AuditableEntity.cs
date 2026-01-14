namespace FinanceApi.Domain.Common;

public abstract class AuditableEntity
{
  
    /// User who created the record
    /// Usuário que criou o registro  
    public Guid CreatedBy { get; protected set; }

  
    /// Creation date and time in UTC
    /// Data e hora da criação em UTC
    public DateTime CreatedAtUtc { get; protected set; }

  
    /// Creation date and time in Brazil local time
    /// Data e hora da criação no horário do Brasil 
    public DateTime CreatedAtLocal { get; protected set; }

  
    /// User who last updated the record
    /// Usuário que alterou o registro 
    public Guid? UpdatedBy { get; protected set; }

  
    /// Last update date and time in UTC
    /// Data e hora da alteração em UTC
    public DateTime? UpdatedAtUtc { get; protected set; }

  
    /// Last update date and time in Brazil local time
    /// Data e hora da alteração no horário do Brasil  
    public DateTime? UpdatedAtLocal { get; protected set; }

  
    /// Indicates whether the record is active
    /// Indica se o registro está ativo  
    public bool IsActive { get; protected set; }

    protected AuditableEntity()
    {
        IsActive = true;
    }

  
    /// Marks the entity as inactive (soft delete)
    /// Marca a entidade como inativa (exclusão lógica) 
    public void Deactivate()
    {
        IsActive = false;
    }

  
    /// Sets creation audit data
    /// Define os dados de auditoria de criação  
    public void SetCreated(Guid userId, DateTime utcNow, DateTime localNow)
    {
        CreatedBy = userId;
        CreatedAtUtc = utcNow;
        CreatedAtLocal = localNow;
    }

  
    /// Sets update audit data
    /// Define os dados de auditoria de alteração
    public void SetUpdated(Guid userId, DateTime utcNow, DateTime localNow)
    {
        UpdatedBy = userId;
        UpdatedAtUtc = utcNow;
        UpdatedAtLocal = localNow;
    }
}
