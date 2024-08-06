using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Doctor;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Doctor
{
    public interface IDoctorService
    {
        Task<Result<IEnumerable<DoctorDto>>> GetDoctorListAsync(CancellationToken cancellationToken);
        Task<Result<DoctorDto>> GetDoctorByIdAsync(string id, CancellationToken cancellationToken);
        Task<Result<DoctorDto>> AddDoctorAsync(CreateDoctorDto doctorDto, CancellationToken cancellationToken);
    }
}
