using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Config
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("MedicalRecords");
            builder.HasKey("MedicalRecordId");
            builder.Property(x => x.VisitDescription).HasMaxLength(200);
            builder.Property(x => x.Diagnosis).HasMaxLength(200);
            builder.Property(x => x.AdditionalNotes).HasMaxLength(200).IsRequired(false);

            builder.HasOne(x => x.Appointment)
                .WithOne(x => x.MedicalRecord)
                .HasForeignKey<MedicalRecord>(x => x.AppointmentId)
                .HasConstraintName("FK_MedicalRecords_Appointments");

            builder.HasIndex(x => x.AppointmentId, "UQ_MedicalRecords_Appointment").IsUnique();
        }
    }
}
