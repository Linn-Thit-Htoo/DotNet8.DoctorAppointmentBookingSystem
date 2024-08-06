namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Doctor;

public interface IDoctorService
{
    Task<Result<IEnumerable<DoctorDto>>> GetDoctorListAsync(CancellationToken cancellationToken);
    Task<Result<DoctorDto>> GetDoctorByIdAsync(string id, CancellationToken cancellationToken);
    Task<Result<DoctorDto>> AddDoctorAsync(
        CreateDoctorDto doctorDto,
        CancellationToken cancellationToken
    );
}
