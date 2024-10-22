﻿namespace DotNet8.DoctorAppointmentBookingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult Content(object obj)
    {
        return Content(JsonConvert.SerializeObject(obj), "application/json");
    }
}
