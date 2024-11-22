using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/udlejning")]
    [ApiController]
    public class UdlejningController : ControllerBase
    {

        private readonly IUdlejningService _udlejningService;

        public UdlejningController(IUdlejningService udlejningService)
        {
            _udlejningService = udlejningService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Udlejning>> GetUdlejningAsync(int id)
        {
            var udlejning = await _udlejningService.GetUdlejningAsync(id);

            if (udlejning == null)
            {
                return NotFound();
            }

            return udlejning;
        }

        [HttpGet]
        public async Task<ActionResult<List<Udlejning>>> GetUdlejningerAsync()
        {
            return await _udlejningService.GetUdlejningerAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Udlejning>> AddUdlejningAsync(Udlejning udlejning)
        {
            await _udlejningService.AddUdlejningAsync(udlejning);

            return Ok(udlejning);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUdlejningAsync(int id, Udlejning udlejning)
        {
            if (id != udlejning.UdlejningId)
            {
                return BadRequest();
            }

            await _udlejningService.UpdateUdlejningAsync(udlejning);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUdlejningAsync(int id)
        {
            await _udlejningService.DeleteUdlejningAsync(id);

            return NoContent();
        }
    }
}
