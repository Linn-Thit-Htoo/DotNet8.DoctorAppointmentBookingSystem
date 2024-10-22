﻿namespace DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Appointment;

public class AppointmentService : IAppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    #region Get Appointments Async

    public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsAsync(
        CancellationToken cancellationToken
    )
    {
        Result<IEnumerable<AppointmentDto>> result;
        try
        {
            var lst = await _context
                .TblAppointments.OrderByDescending(x => x.AppointmentId)
                .ToListAsync(cancellationToken: cancellationToken);
            result = Result<IEnumerable<AppointmentDto>>.Success(lst.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<AppointmentDto>>.Failure(ex);
        }

        return result;
    }

    #endregion

    #region Get Appointment By Id Async

    public async Task<Result<AppointmentDto>> GetAppointmentByIdAsync(
        string id,
        CancellationToken cancellationToken
    )
    {
        Result<AppointmentDto> result;
        try
        {
            var appointment = await _context.TblAppointments.FindAsync(
                [id],
                cancellationToken: cancellationToken
            );
            if (appointment is null)
            {
                result = Result<AppointmentDto>.NotFound("Appointment Not Found.");
                goto result;
            }

            result = Result<AppointmentDto>.Success(appointment.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<AppointmentDto>.Failure(ex);
        }

    result:
        return result;
    }

    #endregion

    #region Get Appointments By Doctor Id Async

    public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctorIdAsync(
        string doctorId,
        CancellationToken cancellationToken
    )
    {
        Result<IEnumerable<AppointmentDto>> result;
        try
        {
            var appointments = await _context
                .TblAppointments.Where(x => x.DoctorId == doctorId)
                .ToListAsync(cancellationToken: cancellationToken);
            if (appointments is null)
            {
                result = Result<IEnumerable<AppointmentDto>>.NotFound("No Appointment Found.");
                goto result;
            }

            result = Result<IEnumerable<AppointmentDto>>.Success(
                appointments.Select(x => x.ToDto())
            );
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<AppointmentDto>>.Failure(ex);
        }

    result:
        return result;
    }

    #endregion

    #region Get Appointments By Patient Id Async

    public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByPatientIdAsync(
        string patientId,
        CancellationToken cancellationToken
    )
    {
        Result<IEnumerable<AppointmentDto>> result;
        try
        {
            var appointments = await _context
                .TblAppointments.Where(x => x.PatientId == patientId)
                .ToListAsync(cancellationToken: cancellationToken);
            if (appointments is null)
            {
                result = Result<IEnumerable<AppointmentDto>>.NotFound("No Appointment Found.");
                goto result;
            }

            result = Result<IEnumerable<AppointmentDto>>.Success(
                appointments.Select(x => x.ToDto())
            );
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<AppointmentDto>>.Failure(ex);
        }

    result:
        return result;
    }

    #endregion

    #region Book Appointment Async

    public async Task<Result<AppointmentDto>> BookAppointmentAsync(
        CreateAppointmentDto appointmentDto,
        CancellationToken cancellationToken
    )
    {
        Result<AppointmentDto> result;
        try
        {
            var doctor = await _context.TblDoctors.FindAsync(
                [appointmentDto.DoctorId],
                cancellationToken: cancellationToken
            );
            if (doctor is null)
            {
                result = Result<AppointmentDto>.NotFound("Doctor Not Found.");
                goto result;
            }

            var patient = await _context.TblPatients.FindAsync(
                [appointmentDto.PatientId],
                cancellationToken: cancellationToken
            );
            if (doctor is null)
            {
                result = Result<AppointmentDto>.NotFound("Patient Not Found.");
                goto result;
            }

            await _context.AddAsync(appointmentDto.ToEntity(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            result = Result<AppointmentDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<AppointmentDto>.Failure(ex);
        }

    result:
        return result;
    }

    #endregion
}
