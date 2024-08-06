using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Doctor;
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

        public async Task<Result<DoctorDto>> GetDoctorByIdAsync(string id, CancellationToken cancellationToken)
        {
            Result<DoctorDto> result;
            try
            {
                var item = await _context.TblDoctors.FindAsync([id], cancellationToken: cancellationToken);
                if (item is null)
                {
                    result = Result<DoctorDto>.NotFound("Doctor Not Found.");
                    goto result;
                }

                result = Result<DoctorDto>.Success(item.ToDto());
            }
            catch (Exception ex)
            {
                result = Result<DoctorDto>.Failure(ex);
            }

        result:
            return result;
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
    }
}
