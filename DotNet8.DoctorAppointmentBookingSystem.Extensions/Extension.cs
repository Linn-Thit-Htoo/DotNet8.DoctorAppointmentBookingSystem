﻿using DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;
using DotNet8.DoctorAppointmentBookingSystem.Models.Features.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Extensions
{
    public static class Extension
    {
        public static TblDoctor ToEntity(this DoctorRequestModel requestModel)
        {
            return new TblDoctor
            {
                DoctorId = Ulid.NewUlid().ToString(),
                DoctorName = requestModel.DoctorName,
                Speciality = requestModel.Speciality
            };
        }
    }
}