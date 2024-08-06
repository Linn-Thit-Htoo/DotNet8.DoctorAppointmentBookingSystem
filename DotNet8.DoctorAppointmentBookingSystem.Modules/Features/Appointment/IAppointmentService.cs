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
        Task<Result<AppointmentDto>> BookAppointmentAsync(CreateAppointmentDto appointment, CancellationToken cancellationToken);
        Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctorIdAsync(string doctorId, CancellationToken cancellationToken);
        Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByPatientIdAsync(string patientId, CancellationToken cancellationToken);
    }
}
