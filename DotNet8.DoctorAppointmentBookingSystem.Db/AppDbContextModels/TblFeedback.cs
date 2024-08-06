namespace DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;

public partial class TblFeedback
{
    public string FeedbackId { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual TblPatient Patient { get; set; } = null!;
}
