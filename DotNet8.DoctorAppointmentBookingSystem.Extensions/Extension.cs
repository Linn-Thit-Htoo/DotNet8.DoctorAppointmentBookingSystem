namespace DotNet8.DoctorAppointmentBookingSystem.Extensions;

public static class Extension
{
    public static TblDoctor ToEntity(this CreateDoctorDto requestModel)
    {
        return new TblDoctor
        {
            DoctorId = Ulid.NewUlid().ToString(),
            DoctorName = requestModel.DoctorName,
            Speciality = requestModel.Speciality
        };
    }

    public static DoctorDto ToDto(this TblDoctor dataModel)
    {
        return new DoctorDto
        {
            DoctorId = dataModel.DoctorId,
            DoctorName = dataModel.DoctorName,
            Speciality = dataModel.Speciality
        };
    }

    public static PatientDto ToDto(this TblPatient dataModel)
    {
        return new PatientDto
        {
            PatientId = dataModel.PatientId,
            PatientName = dataModel.PatientName
        };
    }

    public static TblPatient ToEntity(this CreatePatientDto patientDto)
    {
        return new TblPatient
        {
            PatientId = Ulid.NewUlid().ToString(),
            PatientName = patientDto.PatientName
        };
    }

    public static AppointmentDto ToDto(this TblAppointment dataModel)
    {
        return new AppointmentDto
        {
            AppointmentId = dataModel.AppointmentId,
            Date = dataModel.Date,
            DoctorId = dataModel .DoctorId,
            PatientId= dataModel .PatientId,
            Slot = dataModel.Slot
        };
    }

    public static TblAppointment ToEntity(this CreateAppointmentDto appointmentDto)
    {
        return new TblAppointment
        {
            AppointmentId = Ulid.NewUlid().ToString(),
            Date = DateTime.Now,
            DoctorId= appointmentDto.DoctorId,
            PatientId = appointmentDto.PatientId,
            Slot = appointmentDto.Slot
        };
    }
}