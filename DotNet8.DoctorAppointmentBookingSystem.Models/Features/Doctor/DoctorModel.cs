﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Models.Features.Doctor
{
    public class DoctorModel
    {
        public string DoctorId { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

        public string Speciality { get; set; } = null!;
    }
}