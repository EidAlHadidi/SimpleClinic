using DAL.Context.Config;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //no need for ↓↓↓
            //new appointmentconfiguration().configure(modelbuilder.entity<appointment>());
            //new doctorconfiguration().configure(modelbuilder.entity<doctor>());
            //new medicalrecordconfiguration().configure(modelbuilder.entity<medicalrecord>());
            //new patientconfiguration().configure(modelbuilder.entity<patient>());
            //new paymentconfiguration().configure(modelbuilder.entity<payment>());
            //new personconfiguration().configure(modelbuilder.entity<person>());
            //new prescriptionconfiguration().configure(modelbuilder.entity<prescription>());


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //this code is WRONG and will not work...
            //try to fix it

            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;
        }

    }
}
