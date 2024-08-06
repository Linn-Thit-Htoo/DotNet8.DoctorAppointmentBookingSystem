using DotNet8.DoctorAppointmentBookingSystem.Dtos.Features.Patient;
using DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Patient;
using Microsoft.AspNetCore.Http;

namespace DotNet8.DoctorAppointmentBookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients(CancellationToken cancellationToken)
        {
            var result = await _patientService.GetPatientsAsync(cancellationToken);
            return Content(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(string id, CancellationToken cancellationToken)
        {
            var result = await _patientService.GetPatientByIdAsync(id, cancellationToken);
            return Content(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto patientDto, CancellationToken cancellationToken)
        {
            var result = await _patientService.AddPatientAsync(patientDto, cancellationToken);
            return Content(result);
        }
    }
}
