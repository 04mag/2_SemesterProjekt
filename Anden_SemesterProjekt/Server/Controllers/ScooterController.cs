using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/scootere")]
    [ApiController]
    public class ScooterController :ControllerBase
    {
        private readonly IScooterService _scooterService;

        public ScooterController(IScooterService scooterService)
        {
            _scooterService = scooterService;
        }

        [HttpGet("UdlejningsScootere")]
        public async Task<IActionResult> GetAllUdlejningsScootereAsync()
        {
            var scootere = await _scooterService.ReadUdlejningsScootere();

            // Filtrér scootere baseret på typen, hvis nødvendigt


            return Ok(scootere);
        }
        [HttpGet("KundeScootere")]
        public async Task<IActionResult> GetAllKundeScootereAsync(int kundeId)
        {
            var scootere = await _scooterService.ReadKundeScootereAsync(kundeId);

            // Filtrér scootere baseret på typen, hvis nødvendigt


            return Ok(scootere);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var scooter = await _scooterService.ReadScooterAsync(id);
            if (scooter == null)
            {
                return NotFound($"Ingen scooter fundet med ID {id}.");
            }

            return Ok(scooter);
        }

        [HttpPost("UdlejningsScooter")]
        public async Task<ActionResult> Post(UdlejningsScooter scooter) 
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }
            var addedScooter =  await _scooterService.AddScooterAsync(scooter);
            return Ok(addedScooter);
        }
        [HttpPost("KundeScooter")]
        public async Task<ActionResult> Post(KundeScooter scooter)
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }

            var addedScooter = await _scooterService.AddScooterAsync(scooter);
            return Ok(addedScooter);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Scooter scooter)
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }
            var updatedScooter = await _scooterService.UpdateScooterAsync(scooter);
            return Ok(updatedScooter);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
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
