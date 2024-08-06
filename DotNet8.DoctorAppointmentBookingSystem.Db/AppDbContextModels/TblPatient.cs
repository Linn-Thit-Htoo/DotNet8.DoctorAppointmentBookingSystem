namespace DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;

public partial class TblPatient
{
    public string PatientId { get; set; } = null!;

    public string PatientName { get; set; } = null!;

    public virtual ICollection<TblAppointment> TblAppointments { get; set; } =
        new List<TblAppointment>();

    public virtual ICollection<TblFeedback> TblFeedbacks { get; set; } = new List<TblFeedback>();
}
