using DotNet8.DoctorAppointmentBookingSystem.Modules.Features.Doctor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.DoctorAppointmentBookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctor(CancellationToken cancellationToken)
        {
            var result = await _doctorService.GetDoctorListAsync(cancellationToken);
            return Content(result);
        }
    }
}
