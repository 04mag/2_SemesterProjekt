using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/scootere")]
    [ApiController]
    public class ScooterController<T> :ControllerBase where T : Scooter
    {
        private readonly IScooterService<T> _scooterService;

        public ScooterController(IScooterService<T> scooterService)
        {
            _scooterService = scooterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetScootere()
        {
            var scootere = await _scooterService.GetAllScootereAsync();

            // Filtrér scootere baseret på typen, hvis nødvendigt


            return Ok(scootere);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var scooter = await _scooterService.GetScooterAsync(id);
            if (scooter == null)
            {
                return NotFound($"Ingen udlejnings-scooter fundet med ID {id}.");
            }

            return Ok(scooter);
        }

        [HttpPost]
        public async Task<IActionResult> Post(T scooter) 
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }

         
            await _scooterService.AddScooterAsync(scooter);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(T scooter)
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }
            var updatedScooter = await _scooterService.UpdateScooterAsync(scooter);
            return Ok(updatedScooter);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedId = await _scooterService.DeleteScooterAsync(id);
            if (deletedId == 0)
            {
                return NotFound($"Ingen scooter fundet med ID {id}.");
            }
            return Ok(deletedId);
        }
    }
}
