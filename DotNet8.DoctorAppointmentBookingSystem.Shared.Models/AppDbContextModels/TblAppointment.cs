using System;
using System.Collections.Generic;

namespace DotNet8.DoctorAppointmentBookingSystem.Shared.Models.AppDbContextModels;

public partial class TblAppointment
{
    public string AppointmentId { get; set; } = null!;

    public string DoctorId { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Slot { get; set; } = null!;

    public virtual TblDoctor Doctor { get; set; } = null!;

    public virtual TblPatient Patient { get; set; } = null!;
}
