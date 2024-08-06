using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Appointment
{
    public class AppointmentDto
    {
        public string AppointmentId { get; set; } = null!;

        public string DoctorId { get; set; } = null!;

        public string PatientId { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Slot { get; set; } = null!;
    }
}
