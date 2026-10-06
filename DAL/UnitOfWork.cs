using BL.Interfaces;
using BL.Models;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<Person> People { get; private set; }

        public IBaseRepository<Doctor> Doctors { get; private set; }

        public IBaseRepository<Patient> Patients { get; private set; }

        public IBaseRepository<Payment> Payments { get; private set; }

        public IBaseRepository<Prescription> Prescriptions { get; private set; }

        public IBaseRepository<MedicalRecord> MedicalRecord { get; private set; }

        public IBaseRepository<Appointment> Appointments { get; private set; }

        public int complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
