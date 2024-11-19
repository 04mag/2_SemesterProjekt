using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/scootere")]
    [ApiController]
    public class ScooterController : ControllerBase
    {
        private readonly IScooterService _scooterService;

        public ScooterController(IScooterService scooterService)
        {
            _scooterService = scooterService;
        }

        [HttpGet]
        public async Task<ActionResult<T>> GetUdlejningsScootere<T>() where T : Scooter
        {
            var scootere = await _scooterService.GetAllScootereAsync<T>();
            if (scootere == null || scootere.Count == 0)
            {
                return NotFound("Ingen udlejnings-scootere fundet.");
            }
            return Ok(scootere);
        }

        [HttpGet("kunde")]
        public async Task<IActionResult> GetKundeScootere()
        {
            var scootere = await _scooterService.GetAllScootereAsync<KundeScooter>();
            if (scootere == null || scootere.Count == 0)
            {
                return NotFound("Ingen kunde-scootere fundet.");
            }
            return Ok(scootere);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var scooter = await _scooterService.GetScooterAsync<Scooter>(id);
            if (scooter == null)
            {
                return NotFound($"Ingen udlejnings-scooter fundet med ID {id}.");
            }

            return Ok(scooter);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Scooter scooter) 
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }

            if (scooter is KundeScooter kundeScooter)
            {
                await _scooterService.AddScooterAsync(kundeScooter);
            }
            else if (scooter is UdlejningsScooter udlejningsScooter)
            {
                await _scooterService.AddScooterAsync(udlejningsScooter);
            }
            else
            {
                return BadRequest("Unknown scooter type");
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UdlejningsScooter scooter)
        {
            if (scooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }
            var updatedScooter = await _scooterService.UpdateScooterAsync<UdlejningsScooter>(scooter);
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
