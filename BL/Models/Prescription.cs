using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int MedicalRecordId { get; set; }
        public string MedicationName { get; set; } = null!;
        public string Dosage { get; set; } = null!;
        public string Frequency { get; set; } = null!;
        public DateOnly StartDate {  get; set; }
        public DateOnly EndDate { get; set; }
        public string? SpecialInstructions { get; set; }

        public MedicalRecord MedicalRecord { get; set; } = null!;

    }
}
