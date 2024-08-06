using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Appointment
{
    public class CreateAppointmentDto
    {
        public string DoctorId { get; set; } = null!;

        public string PatientId { get; set; } = null!;

        public string Slot { get; set; } = null!;
    }
}
