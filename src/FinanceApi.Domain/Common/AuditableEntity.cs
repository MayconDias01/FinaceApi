using System;

namespace FinanceApi.Domain.Common
{
    public abstract class AuditableEntity
    {
        // --- A CORREÇÃO ESTÁ AQUI ---
        // Toda entidade precisa de identidade. Iniciamos com um Guid novo pra facilitar.
        public Guid Id { get; set; } = Guid.NewGuid();
        // -----------------------------

        /// User who created the record
        public Guid CreatedBy { get; protected set; }

        /// Creation date and time in UTC
        public DateTime CreatedAtUtc { get; protected set; }

        /// Creation date and time in Brazil local time
        public DateTime CreatedAtLocal { get; protected set; }

        /// User who last updated the record
        public Guid? UpdatedBy { get; protected set; }

        /// Last update date and time in UTC
        public DateTime? UpdatedAtUtc { get; protected set; }

        /// Last update date and time in Brazil local time
        public DateTime? UpdatedAtLocal { get; protected set; }

        /// Indicates whether the record is active
        public bool IsActive { get; protected set; }

        protected AuditableEntity()
        {
            IsActive = true;
        }

        /// Marks the entity as inactive (soft delete)
        public void Deactivate()
        {
            IsActive = false;
        }

        /// Sets creation audit data
        public void SetCreated(Guid userId, DateTime utcNow, DateTime localNow)
        {
            CreatedBy = userId;
            CreatedAtUtc = utcNow;
            CreatedAtLocal = localNow;
        }

        /// Sets update audit data
        public void SetUpdated(Guid userId, DateTime utcNow, DateTime localNow)
        {
            UpdatedBy = userId;
            UpdatedAtUtc = utcNow;
            UpdatedAtLocal = localNow;
        }
    }
}