namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Patient;

public interface IPatientService
{
    Task<Result<IEnumerable<PatientDto>>> GetPatientsAsync(CancellationToken cancellationToken);
    Task<Result<PatientDto>> GetPatientByIdAsync(string id, CancellationToken cancellationToken);
    Task<Result<PatientDto>> AddPatientAsync(
        CreatePatientDto patientDto,
        CancellationToken cancellationToken
    );
}
