using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public int PersonId { get; set; }
        public string Specialization { get; set; } = null!;
        public Person Person { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
