using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/scooter")]
    [ApiController]
    public class ScooterController : ControllerBase
    {
        private readonly IScooterService _service;

        public ScooterController(IScooterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var scootere = await _service.GetAllScootereAsync();
            if (scootere == null || scootere.Count == 0)
            {
                return NotFound("Ingen scootere fundet.");
            }
            return Ok(scootere);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var scooter = await _service.GetScooterByIdAsync(id);
            if (scooter == null)
            {
                return NotFound($"Ingen scooter fundet med ID {id}.");
            }
            return Ok(scooter);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Scooter scooter)
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }

            var createdScooter = await _service.AddScooterAsync(scooter);
            return CreatedAtAction(nameof(Get), new { id = createdScooter.Id }, createdScooter);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Scooter scooter)
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }

            var updatedScooter = await _service.UpdateScooterAsync(scooter);
            return Ok(updatedScooter);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteScooterAsync(id);
            if (!success)
            {
                return NotFound($"Ingen scooter fundet med ID {id}.");
            }
            return NoContent();
        }
    }
}
