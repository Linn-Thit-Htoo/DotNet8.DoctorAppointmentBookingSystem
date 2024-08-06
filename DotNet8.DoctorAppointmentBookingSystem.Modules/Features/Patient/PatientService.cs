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

        public async Task<Result<IEnumerable<PatientDto>>> GetPatientsAsync(CancellationToken cancellationToken)
        {
            Result<IEnumerable<PatientDto>> result;
            try
            {
                var lst = await _context.TblPatients.OrderByDescending(x => x.PatientId).ToListAsync(cancellationToken);
                result = Result<IEnumerable<PatientDto>>.Success(lst.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<PatientDto>>.Failure(ex);
            }

            return result;
        }

        public async Task<Result<PatientDto>> GetPatientByIdAsync(string id, CancellationToken cancellationToken)
        {
            Result<PatientDto> result;
            try
            {
                var item = await _context.TblPatients.FindAsync([id], cancellationToken: cancellationToken);
                if (item is null)
                {
                    result = Result<PatientDto>.NotFound("No Patient Found.");
                    goto result;
                }

                result = Result<PatientDto>.Success(item.ToDto());
            }
            catch (Exception ex)
            {
                result = Result<PatientDto>.Failure(ex);
            }

        result:
            return result;
        }

        public async Task<Result<PatientDto>> AddPatientAsync(CreatePatientDto patientDto, CancellationToken cancellationToken)
        {
            Result<PatientDto> result;
            try
            {
                await _context.TblPatients.AddAsync(patientDto.ToEntity(), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                result = Result<PatientDto>.SaveSuccess();
            }
            catch (Exception ex)
            {
                result = Result<PatientDto>.Failure(ex);
            }

            return result;
        }
    }
}
