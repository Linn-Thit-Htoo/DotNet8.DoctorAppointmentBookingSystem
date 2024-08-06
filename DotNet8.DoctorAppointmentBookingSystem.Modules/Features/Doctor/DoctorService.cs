using DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;
using DotNet8.DoctorAppointmentBookingSystem.Extensions;
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

        public async Task<Result<DoctorResponseModel>> AddDoctorAsync(DoctorRequestModel requestModel, CancellationToken cancellationToken)
        {
            Result<DoctorResponseModel> result;
            try
            {
                await _context.TblDoctors.AddAsync(requestModel.ToEntity(), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                result = Result<DoctorResponseModel>.SaveSuccess();
            }
            catch (Exception ex)
            {
                result = Result<DoctorResponseModel>.Failure(ex);
            }

            return result;
        }
    }
}
