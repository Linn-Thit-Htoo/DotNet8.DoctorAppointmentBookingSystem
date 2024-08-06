namespace DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Appointment;

public class CreateAppointmentDto
{
    public string DoctorId { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public string Slot { get; set; } = null!;
}
