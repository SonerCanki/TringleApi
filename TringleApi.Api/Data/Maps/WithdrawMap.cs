using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Entities;
using TringleApi.Common.Enums;

namespace TringleApi.Api.Data.Maps
{
    public class WithdrawMap : IEntityTypeConfiguration<Withdraw>
    {
        public void Configure(EntityTypeBuilder<Withdraw> builder)
        {
            builder.ToTable("Withdraws");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.Amount).IsRequired(true);
            builder.Property(x => x.TransactionType).HasDefaultValue(TransactionType.Withdraw).IsRequired(true);

            builder
                .HasOne(d => d.Account)
                .WithMany(a => a.Withdraws)
                .HasForeignKey(d => d.AccountId);
        }
    }
}
