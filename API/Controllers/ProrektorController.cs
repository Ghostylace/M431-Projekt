using API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Prorektor;

namespace API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ProrektorController : ControllerBase
{
    private readonly IProrektorService _prorektorService;

    public ProrektorController(IProrektorService prorektorService)
    {
        _prorektorService = prorektorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProrektorDTO>?>> GetAll()
    {
        List<ProrektorDTO>? result = await _prorektorService.GetAll();

        if(result == null)
        {
            return BadRequest("Something went wrong while getting shi");
        }

        return Ok(result);
    }
}
