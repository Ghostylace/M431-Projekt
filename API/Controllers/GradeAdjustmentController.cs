using Microsoft.AspNetCore.Mvc;
using API.Services.Abstract;
using Shared.DTOs.GradAdjustment;

namespace API.Controllers;

[ApiController]
[Route("api/grade-adjustments")]
public class GradeAdjustmentsController : ControllerBase
{
    private readonly IGradeAdjustmentService _service;

    /// <summary>
    /// Constructor for DI
    /// </summary>
    /// <param name="service">Parameter for DI</param>
    public GradeAdjustmentsController(IGradeAdjustmentService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves all items from the service.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the collection of items returned by the service. The result has an
    /// HTTP 200 status code with the items in the response body.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.GetAllAsync());

    /// <summary>
    /// Creates a new grade adjustment based on the specified request data.
    /// </summary>
    /// <param name="request">The details of the grade adjustment to create. Must not be null.</param>
    /// <returns>An <see cref="IActionResult"/> that represents the result of the create operation. Returns a 200 OK response
    /// with the created grade adjustment details if successful.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGradeAdjustmentRequest request)
        => Ok(await _service.CreateAsync(request));

    /// <summary>
    /// Updates the status of a grade adjustment with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the grade adjustment to update.</param>
    /// <param name="request">An object containing the new status information for the grade adjustment. Cannot be null.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation. Returns 200 OK if the update is
    /// successful; otherwise, returns 404 Not Found if the grade adjustment does not exist.</returns>
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id,UpdateGradeAdjustmentStatusRequest request)
    {
        bool isSuccess = await _service.UpdateStatusAsync(id, request);

        if (isSuccess)
            return Ok("Successfully updated Grade");
        return NotFound("Grade not found");
    }
}
