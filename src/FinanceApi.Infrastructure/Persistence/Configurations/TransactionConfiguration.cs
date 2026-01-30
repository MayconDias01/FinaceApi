using FinanceApi.Domain.Entities;
using FinanceApi.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApi.Infrastructure.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);

            // Relacionamento com Wallet
            builder.HasOne<Wallet>()
                .WithMany()
                .HasForeignKey(t => t.WalletId)
                .IsRequired();

            // Mapeamento dos Enums como String (Melhor para leitura no banco)
            builder.Property(t => t.Type)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(t => t.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(500) // Aumentei um pouco para caber observações longas
                .IsRequired();

            // Campos de Data (opcionais pois podem ser agendamentos)
            builder.Property(t => t.DueDate).IsRequired(false);
            builder.Property(t => t.PaymentDate).IsRequired(false);
            builder.Property(t => t.CategoryId).IsRequired(false);

            // Value Object Money
            builder.OwnsOne<Money>(t => t.Amount, navigation =>
            {
                navigation.Property(m => m.Amount)
                    .HasColumnName("Amount")
                    .HasPrecision(18, 2)
                    .IsRequired();

                navigation.Property(m => m.Currency)
                    .HasColumnName("Currency")
                    .HasMaxLength(3)
                    .IsRequired();
            });
        }
    }
}