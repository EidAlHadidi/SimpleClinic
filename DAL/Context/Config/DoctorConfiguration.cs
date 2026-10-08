using BL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Config
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey("DoctorId");
            builder.Property(x => x.Specialization).HasMaxLength(100);

            builder.HasIndex(x => x.PersonId, "UQ_Doctors_Person").IsUnique();

            builder.HasOne(x => x.Person)
                .WithOne(x => x.Doctor)
                .HasForeignKey<Doctor>(x => x.PersonId)
                .HasConstraintName("FK_Doctors_People");
        }
    }   
}
