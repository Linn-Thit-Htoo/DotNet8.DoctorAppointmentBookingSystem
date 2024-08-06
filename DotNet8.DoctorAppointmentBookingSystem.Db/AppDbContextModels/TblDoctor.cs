using System;
using System.Collections.Generic;

namespace DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;

public partial class TblDoctor
{
    public string DoctorId { get; set; } = null!;

    public string DoctorName { get; set; } = null!;

    public string Speciality { get; set; } = null!;

    public virtual ICollection<TblAppointment> TblAppointments { get; set; } = new List<TblAppointment>();
}
