using API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        /// <summary>
        /// Constructor for DI
        /// </summary>
        /// <param name="service">Parameter for DI</param>
        public StudentsController(IStudentService service)
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
    }

}
