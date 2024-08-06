using DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.DoctorAppointmentBookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments(CancellationToken cancellationToken)
        {
            var result = await _appointmentService.GetAppointmentsAsync(cancellationToken);
            return Content(result);
        }
    }
}
