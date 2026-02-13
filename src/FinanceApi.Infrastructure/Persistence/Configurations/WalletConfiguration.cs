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
            builder.HasKey(wallet => wallet.Id);


            builder.OwnsOne(wallet => wallet.Balance, navigation =>
            {

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