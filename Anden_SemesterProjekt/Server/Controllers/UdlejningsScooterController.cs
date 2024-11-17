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
    public class UdlejningsScooterController : ControllerBase
    {
        private readonly IUdlejningsScooterService _udlejningsScooterService;

        public UdlejningsScooterController(IUdlejningsScooterService udlejningsScooterService)
        {
            _udlejningsScooterService = udlejningsScooterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UdlejningsScooter>>> Get()
        {
            var scootere = await _udlejningsScooterService.GetAllUdlejningsScootereAsync();
            if (scootere == null || scootere.Count == 0)
            {
                return NotFound("Ingen udlejnings-scootere fundet.");
            }
            return Ok(scootere);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UdlejningsScooter>> Get(int id)
        {
            var scooter = await _udlejningsScooterService.GetUdlejningsScooterAsync(id);
            if (scooter == null)
            {
                return NotFound($"Ingen udlejnings-scooter fundet med ID {id}.");
            }
            return Ok(scooter);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(UdlejningsScooter udlejningsScooter)
        {
            if (udlejningsScooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }

            var id = await _udlejningsScooterService.AddUdlejningsScooterAsync(udlejningsScooter);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> Put(UdlejningsScooter udlejningsScooter)
        {
            if (udlejningsScooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }

            var id = await _udlejningsScooterService.UpdateUdlejningsScooterAsync(udlejningsScooter);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var deletedId = await _udlejningsScooterService.RemoveUdlejningsScooterAsync(id);
            if (deletedId == 0)
            {
                return NotFound($"Ingen udlejnings-scooter fundet med ID {id}.");
            }
            return Ok(deletedId);
        }
    }
}
