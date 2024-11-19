using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/udlejningsscooter")]
    [ApiController]
    public class ScooterController : ControllerBase
    {
        private readonly IScooterService _udlejningsScooterService;

        public ScooterController(IScooterService udlejningsScooterService)
        {
            _udlejningsScooterService = udlejningsScooterService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var scootere = await _udlejningsScooterService.GetAllUdlejningsScootereAsync();
            if (scootere == null || scootere.Count == 0)
            {
                return NotFound("Ingen udlejnings-scootere fundet.");
            }
            return Ok(scootere);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var scooter = await _udlejningsScooterService.GetScooterAsync(id);
            if (scooter == null)
            {
                return NotFound($"Ingen udlejnings-scooter fundet med ID {id}.");
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

            var createdScooter = await _udlejningsScooterService.AddScooterAsync(scooter);


            return Ok(createdScooter);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Scooter scooter)
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }
            var updatedScooter = await _udlejningsScooterService.UpdateScooterAsync(scooter);
            return Ok(updatedScooter);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedId = await _udlejningsScooterService.DeleteScooterAsync(id);
            if (deletedId == 0)
            {
                return NotFound($"Ingen udlejnings-scooter fundet med ID {id}.");
            }
            return Ok(deletedId);
        }
    }
}
