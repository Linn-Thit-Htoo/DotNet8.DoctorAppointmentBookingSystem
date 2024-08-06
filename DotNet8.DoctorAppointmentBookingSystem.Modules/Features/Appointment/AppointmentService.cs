using DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Appointment;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Utils;
using DotNet8.DoctorAppointmentBookingSystem.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsAsync(CancellationToken cancellationToken)
        {
            Result<IEnumerable<AppointmentDto>> result;
            try
            {
                var lst = await _context.TblAppointments.OrderByDescending(x => x.AppointmentId).ToListAsync(cancellationToken: cancellationToken);
                result = Result<IEnumerable<AppointmentDto>>.Success(lst.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<AppointmentDto>>.Failure(ex);
            }

            return result;
        }

        public async Task<Result<AppointmentDto>> GetAppointmentByIdAsync(string id, CancellationToken cancellationToken)
        {
            Result<AppointmentDto> result;
            try
            {
                var appointment = await _context.TblAppointments.FindAsync([id], cancellationToken: cancellationToken);
                if (appointment is null)
                {
                    result = Result<AppointmentDto>.NotFound("Appointment Not Found.");
                    goto result;
                }

                result = Result<AppointmentDto>.Success(appointment.ToDto());
            }
            catch (Exception ex)
            {
                result = Result<AppointmentDto>.Failure(ex);
            }

        result:
            return result;
        }

        public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctorIdAsync(string doctorId)
        {
            Result<IEnumerable<AppointmentDto>> result;
            try
            {
                var appointments = await _context.TblAppointments.Where(x => x.DoctorId == doctorId).ToListAsync();
                if (appointments is null)
                {
                    result = Result<IEnumerable<AppointmentDto>>.NotFound("No Appointment Found.");
                    goto result;
                }

                result = Result<IEnumerable<AppointmentDto>>.Success(appointments.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<AppointmentDto>>.Failure(ex);
            }

        result:
            return result;
        }

        public Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<AppointmentDto>> BookAppointmentAsync(CreateAppointmentDto appointmentDto, CancellationToken cancellationToken)
        {
            Result<AppointmentDto> result;
            try
            {
                await _context.AddAsync(appointmentDto.ToEntity(), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                result = Result<AppointmentDto>.SaveSuccess();
            }
            catch (Exception ex)
            {
                result = Result<AppointmentDto>.Failure(ex);
            }

            return result;
        }
    }
}
