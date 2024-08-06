﻿using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Patient;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Patient
{
    public interface IPatientService
    {
        Task<Result<IEnumerable<PatientDto>>> GetPatients();
    }
}
