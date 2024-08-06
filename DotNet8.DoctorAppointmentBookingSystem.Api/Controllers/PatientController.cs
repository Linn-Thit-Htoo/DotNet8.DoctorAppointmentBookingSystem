using DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Patient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
