﻿namespace DotNet8.DoctorAppointmentBookingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : BaseController
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    #region Get Doctors

    [HttpGet]
    public async Task<IActionResult> GetDoctors(CancellationToken cancellationToken)
    {
        var result = await _doctorService.GetDoctorListAsync(cancellationToken);
        return Content(result);
    }

    #endregion

    #region Get Doctor

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctor(string id, CancellationToken cancellationToken)
    {
        var result = await _doctorService.GetDoctorByIdAsync(id, cancellationToken);
        return Content(result);
    }

    #endregion

    #region Create Doctor

    [HttpPost]
    public async Task<IActionResult> CreateDoctor(
        [FromBody] CreateDoctorDto doctorDto,
        CancellationToken cancellationToken
    )
    {
        var result = await _doctorService.AddDoctorAsync(doctorDto, cancellationToken);
        return Content(result);
    }

    #endregion
}
