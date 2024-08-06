﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Doctor
{
    public class DoctorDto
    {
        public string DoctorId { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

        public string Speciality { get; set; } = null!;
    }
}