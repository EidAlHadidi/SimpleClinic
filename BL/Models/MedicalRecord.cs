using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }
        public int AppointmentId { get; set; }
        public string VisitDescription { get; set; } = null!;
        public string Diagnosis { get; set; } = null!;
        public string? AdditionalNotes { get; set; }
        public Appointment Appointment { get; set; } = null!;
        public Prescription? Prescription { get; set; } = null!;
    }
}
