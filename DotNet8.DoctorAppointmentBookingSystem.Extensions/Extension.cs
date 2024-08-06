using DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Doctor;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Extensions
{
    public static class Extension
    {
        public static TblDoctor ToEntity(this CreateDoctorDto requestModel)
        {
            return new TblDoctor
            {
                DoctorId = Ulid.NewUlid().ToString(),
                DoctorName = requestModel.DoctorName,
                Speciality = requestModel.Speciality
            };
        }

        public static DoctorDto ToDto(this TblDoctor dataModel)
        {
            return new DoctorDto
            {
                DoctorId = dataModel.DoctorId,
                DoctorName = dataModel.DoctorName,
                Speciality = dataModel.Speciality
            };
        }

        public static PatientDto ToDto(this TblPatient dataModel)
        {
            return new PatientDto
            {
                PatientId = dataModel.PatientId,
                PatientName = dataModel.PatientName
            };
        }

        public static TblPatient ToEntity(this CreatePatientDto patientDto)
        {
            return new TblPatient
            {
                PatientId = Ulid.NewUlid().ToString(),
                PatientName = patientDto.PatientName
            };
        }
    }
}
