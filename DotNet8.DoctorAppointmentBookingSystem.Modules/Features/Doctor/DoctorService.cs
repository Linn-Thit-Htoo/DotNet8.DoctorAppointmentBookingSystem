using DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;
using DotNet8.DoctorAppointmentBookingSystem.Models.Features.Doctor;
using DotNet8.DoctorAppointmentBookingSystem.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Doctor
{
    public class DoctorService : IDoctorService
    {
        private readonly DoctorAppointmentBookingSystemContext _context;

        public DoctorService(DoctorAppointmentBookingSystemContext context)
        {
            _context = context;
        }

        public Task<Result<DoctorResponseModel>> AddDoctor(DoctorRequestModel requestModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
