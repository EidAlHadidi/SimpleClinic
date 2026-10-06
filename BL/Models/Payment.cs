using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int AppointmentId { get; set; }
        public DateOnly PaymentDate {  get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal AmountPaid { get; set; }
        public string? AdditionalNotes { get; set; }

        public Appointment Appointment { get; set; } = null!;

    }
}
