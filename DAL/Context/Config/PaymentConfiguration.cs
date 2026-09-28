using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Config
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey("PaymentId");
            builder.Property(x => x.PaymentDate).HasColumnType("date");
            builder.Property(x => x.PaymentMethod).HasMaxLength(50);
            builder.Property(x => x.AmountPaid).HasColumnType("decimal(18,0)");
            builder.Property(x => x.AdditionalNotes).HasMaxLength(200).IsRequired(false);

            builder.HasOne(x => x.Appointment)
                .WithOne(x => x.Payment)
                .HasForeignKey<Payment>(x => x.AppointmentId)
                .HasConstraintName("FK_Payments_Appointments");

            builder.HasIndex(x => x.AppointmentId, "UQ_Payments_Appointment").IsUnique();
        }
    }
}
