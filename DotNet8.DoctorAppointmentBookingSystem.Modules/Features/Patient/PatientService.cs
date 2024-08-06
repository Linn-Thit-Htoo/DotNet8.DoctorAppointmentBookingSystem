using DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Patient;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Utils;
using DotNet8.DoctorAppointmentBookingSystem.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Patient
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<PatientDto>>> GetPatients()
        {
            Result<IEnumerable<PatientDto>> result;
            try
            {
                var lst = await _context.TblPatients.OrderByDescending(x => x.PatientId).ToListAsync();
                result = Result<IEnumerable<PatientDto>>.Success(lst.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<PatientDto>>.Failure(ex);
            }

            return result;
        }
    }
}
