using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Doctor
{
    public class DoctorRequestModel
    {
        public string DoctorName { get; set; } = null!;

        public string Speciality { get; set; } = null!;
    }
}
