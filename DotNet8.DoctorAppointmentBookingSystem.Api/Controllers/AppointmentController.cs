using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Appointment;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(string id, CancellationToken cancellationToken)
        {
            var result = await _appointmentService.GetAppointmentByIdAsync(id, cancellationToken);
            return Content(result);
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment([FromBody] CreateAppointmentDto appointmentDto, CancellationToken cancellationToken)
        {
            var result = await _appointmentService.BookAppointmentAsync(appointmentDto, cancellationToken);
            return Content(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentsByDoctorId(string doctorId, CancellationToken cancellationToken)
        {
            var result = await _appointmentService.GetAppointmentsByDoctorIdAsync(doctorId, cancellationToken);
            return Content(result);
        }
    }
}
