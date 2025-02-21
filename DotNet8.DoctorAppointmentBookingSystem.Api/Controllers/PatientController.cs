﻿namespace DotNet8.DoctorAppointmentBookingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : BaseController
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    #region Get Patients

    [HttpGet]
    public async Task<IActionResult> GetPatients(CancellationToken cancellationToken)
    {
        var result = await _patientService.GetPatientsAsync(cancellationToken);
        return Content(result);
    }

    #endregion

    #region Get Patient

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(string id, CancellationToken cancellationToken)
    {
        var result = await _patientService.GetPatientByIdAsync(id, cancellationToken);
        return Content(result);
    }

    #endregion

    #region Create Patient

    [HttpPost]
    public async Task<IActionResult> CreatePatient(
        [FromBody] CreatePatientDto patientDto,
        CancellationToken cancellationToken
    )
    {
        var result = await _patientService.AddPatientAsync(patientDto, cancellationToken);
        return Content(result);
    }

    #endregion
}
