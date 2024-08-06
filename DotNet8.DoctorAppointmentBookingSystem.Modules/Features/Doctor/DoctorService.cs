using DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Doctor;
using DotNet8.DoctorAppointmentBookingSystem.Dtos.Utils;
using DotNet8.DoctorAppointmentBookingSystem.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Doctor
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<DoctorDto>> AddDoctorAsync(CreateDoctorDto requestModel, CancellationToken cancellationToken)
        {
            Result<DoctorDto> result;
            try
            {
                await _context.TblDoctors.AddAsync(requestModel.ToEntity(), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                result = Result<DoctorDto>.SaveSuccess();
            }
            catch (Exception ex)
            {
                result = Result<DoctorDto>.Failure(ex);
            }

            return result;
        }

        public async Task<Result<IEnumerable<DoctorDto>>> GetDoctorListAsync(CancellationToken cancellationToken)
        {
            Result<IEnumerable<DoctorDto>> result;
            try
            {
                var lst = await _context.TblDoctors.OrderByDescending(x => x.DoctorId)
                    .ToListAsync();

                result = Result<IEnumerable<DoctorDto>>.Success(lst.Select(x => x.ToDto()));
            }
            catch (Exception ex)
            {
                result = Result<IEnumerable<DoctorDto>>.Failure(ex);
            }

            return result;
        }
    }
}
