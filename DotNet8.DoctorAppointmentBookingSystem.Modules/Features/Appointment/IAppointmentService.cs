using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Appointment;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Appointment
{
    public interface IAppointmentService
    {
        Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsAsync(CancellationToken cancellationToken);
        Task<Result<AppointmentDto>> GetAppointmentByIdAsync(string id, CancellationToken cancellationToken);
    }
}
