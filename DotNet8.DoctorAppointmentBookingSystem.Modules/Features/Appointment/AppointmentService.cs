using DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Appointment;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Utils;
using DotNet8.DoctorAppointmentBookingSystem.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var lst = await _context.TblAppointments.OrderByDescending(x => x.AppointmentId).ToListAsync();
                result = Result<IEnumerable<AppointmentDto>>.Success(lst.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<AppointmentDto>>.Failure(ex);
            }

            return result;
        }
    }
}
