using FinanceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FinanceApi.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApi.Infrastructure.Persistence.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            // Configura a PK
            builder.HasKey(wallet => wallet.Id);

            // PRESTE ATENÇÃO NOS NOMES DAS VARIÁVEIS AQUI EMBAIXO
            // wallet = A sua classe
            // navigation = A ferramenta de configuração do EF Core

            builder.OwnsOne(wallet => wallet.Balance, navigation =>
            {
                // Aqui dentro, você DEVE usar 'navigation', e não 'wallet'

                navigation.Property(money => money.Amount)
                    .HasColumnName("BalanceAmount")
                    .HasPrecision(18, 2)
                    .IsRequired();

                navigation.Property(money => money.Currency)
                    .HasColumnName("BalanceCurrency")
                    .HasMaxLength(3)
                    .IsRequired();
            });
        }
    }
}