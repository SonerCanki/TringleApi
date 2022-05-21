using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Entities;

namespace TringleApi.Api.Data.Maps
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.Amount).IsRequired(true);

            builder
                .HasOne(a => a.ReciverAccount)
                .WithMany(p => p.ReciverPayments)
                .HasForeignKey(a => a.ReceiverAccountId)
                .IsRequired(true);


            builder
                .HasOne(a => a.SenderAccount)
                .WithMany(p => p.SenderPayments)
                .HasForeignKey(a => a.SenderAccountId)
                .IsRequired(true);
        }
    }
}
