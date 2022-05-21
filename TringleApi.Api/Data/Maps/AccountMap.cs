using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Data.Maps
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.AccountNumber).IsRequired(true);
            builder.Property(x => x.CurrencyCode).IsRequired(true);
            builder.Property(x => x.AccountType).IsRequired(true);
            builder.Property(x => x.Balance).HasDefaultValue(0);

            builder
                .HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.UserId)
                .IsRequired(true);
        }
    }
}
