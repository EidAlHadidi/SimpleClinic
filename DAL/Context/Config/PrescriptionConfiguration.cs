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
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions");
            builder.HasKey("PrescriptionId");
            builder.Property(x => x.MedicationName).HasMaxLength(100);
            builder.Property(x => x.Dosage).HasMaxLength(50);
            builder.Property(x => x.Frequency).HasMaxLength(50);
            builder.Property(x => x.StartDate).HasColumnType("date");
            builder.Property(x => x.EndDate).HasColumnType("date");
            builder.Property(x => x.SpecialInstructions).HasMaxLength(200).IsRequired(false);

            builder.HasOne(x => x.MedicalRecord)
                .WithOne(x => x.Prescription)
                .HasForeignKey<Prescription>(x => x.MedicalRecordId)
                .HasConstraintName("FK_Prescriptions_MedicalRecords");

            builder.HasIndex(x => x.PrescriptionId, "UQ_Record_Prescription").IsUnique();
        }
    }
}
