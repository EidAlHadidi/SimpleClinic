using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepository<Person> People { get; }
        public IBaseRepository<Doctor> Doctors { get; }
        public IBaseRepository<Patient> Patients { get; }
        public IBaseRepository<Payment> Payments { get; }
        public IBaseRepository<Prescription> Prescriptions { get; }
        public IBaseRepository<MedicalRecord> MedicalRecords{ get; }
        public IBaseRepository<Appointment> Appointments { get; }

        int complete();

    }
}
