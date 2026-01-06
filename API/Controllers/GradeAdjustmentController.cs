using Microsoft.AspNetCore.Mvc;
using API.Services.Abstract;
using Shared.DTOs.GradAdjustment;

namespace API.Controllers;

[ApiController]
[Route("api/grade-adjustments")]
public class GradeAdjustmentsController : ControllerBase
{
    private readonly IGradeAdjustmentService _service;

    public GradeAdjustmentsController(IGradeAdjustmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateGradeAdjustmentRequest request)
        => Ok(await _service.CreateAsync(request));

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
        int id,
        UpdateGradeAdjustmentStatusRequest request)
    {
        await _service.UpdateStatusAsync(id, request);
        return NoContent();
    }
}
