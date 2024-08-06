namespace DotNet8.DoctorAppointmentBookingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : BaseController
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    #region Get Appointments

    [HttpGet]
    public async Task<IActionResult> GetAppointments(CancellationToken cancellationToken)
    {
        var result = await _appointmentService.GetAppointmentsAsync(cancellationToken);
        return Content(result);
    }

    #endregion

    #region Get Appointment

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(string id, CancellationToken cancellationToken)
    {
        var result = await _appointmentService.GetAppointmentByIdAsync(id, cancellationToken);
        return Content(result);
    }

    #endregion

    #region Book Appointment

    [HttpPost]
    public async Task<IActionResult> BookAppointment(
        [FromBody] CreateAppointmentDto appointmentDto,
        CancellationToken cancellationToken
    )
    {
        var result = await _appointmentService.BookAppointmentAsync(
            appointmentDto,
            cancellationToken
        );
        return Content(result);
    }

    #endregion

    #region Get Appointments By Doctor Id

    [HttpGet("doctor/{doctorId}")]
    public async Task<IActionResult> GetAppointmentsByDoctorId(
        string doctorId,
        CancellationToken cancellationToken
    )
    {
        var result = await _appointmentService.GetAppointmentsByDoctorIdAsync(
            doctorId,
            cancellationToken
        );
        return Content(result);
    }

    #endregion

    #region Get Appointments By Patient Id

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetAppointmentsByPatientId(
        string patientId,
        CancellationToken cancellationToken
    )
    {
        var result = await _appointmentService.GetAppointmentsByPatientIdAsync(
            patientId,
            cancellationToken
        );
        return Content(result);
    }

    #endregion
}
