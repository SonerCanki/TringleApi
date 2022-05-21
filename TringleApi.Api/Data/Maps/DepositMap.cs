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
    public class DepositMap : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder.ToTable("Deposits");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.Amount).IsRequired(true);
            builder.Property(x => x.TransactionType).HasDefaultValue(TransactionType.Deposit).IsRequired(true);

            builder
                .HasOne(d => d.Account)
                .WithMany(a => a.Deposits)
                .HasForeignKey(d=>d.AccountId);
        }
    }
}
