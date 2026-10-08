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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey("PatientId");
            builder.HasIndex(x => x.PersonId,"UQ_Patients_Person").IsUnique();

            builder.HasOne(x => x.Person)
                .WithOne(x => x.Patient)
                .HasForeignKey<Patient>(x => x.PersonId)
                .HasConstraintName("FK_Patients_People");
        }
    }
}
