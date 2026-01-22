using API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/teachers")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _service;

    /// <summary>
    /// Constructor for DI
    /// </summary>
    /// <param name="service">Parameter for DI</param>
    public TeachersController(ITeacherService service)
    {
        _service = service;
    }

    /// <summary>
    /// Handles HTTP GET requests to retrieve all items.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the collection of items. Returns an HTTP 200 response with the items
    /// if successful.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.GetAllAsync());
}

