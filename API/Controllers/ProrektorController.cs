using API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Prorektor;

namespace API.Controllers;

[ApiController]
[Route("api/prorectors")]
public class ProrectorsController : ControllerBase
{
    private readonly IProrectorService _service;

    public ProrectorsController(IProrectorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.GetAllAsync());
}

