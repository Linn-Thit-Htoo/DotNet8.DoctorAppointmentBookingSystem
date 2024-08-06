using DotNet8.DoctorAppointmentBookingSystem.Models.Features.Doctor;
using DotNet8.DoctorAppointmentBookingSystem.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Doctor
{
    public interface IDoctorService
    {
        Task<Result<DoctorResponseModel>> AddDoctorAsync(DoctorRequestModel requestModel, CancellationToken cancellationToken);
    }
}
