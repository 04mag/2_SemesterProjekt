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
        private readonly IMærkeService _mærkeService;

        public UdlejningsScooterController(IUdlejningsScooterService udlejningsScooterService, IMærkeService mærkeService)
        {
            _udlejningsScooterService = udlejningsScooterService;
            _mærkeService = mærkeService;
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
            var scooter = await _udlejningsScooterService.GetUdlejningsScooterAsync(id);
            if (scooter == null)
            {
                return NotFound($"Ingen udlejnings-scooter fundet med ID {id}.");
            }

            return Ok(scooter);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UdlejningsScooter udlejningsScooter) 
        {
            if (udlejningsScooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }

            if (udlejningsScooter.MærkeId == 0)
            {
                return BadRequest("MærkeId er påkrævet.");
            }

            // Hent Mærke baseret på MærkeId
            var mærke = await _mærkeService.GetMærkeAsync(udlejningsScooter.MærkeId);
            if (mærke == null)
            {
                return BadRequest("Ugyldigt MærkeId.");
            }

            // Sæt det hentede Mærke på UdlejningsScooter
            udlejningsScooter.Mærke = mærke;

            // Gem scooteren i databasen
            var createdScooter = await _udlejningsScooterService.AddUdlejningsScooterAsync(udlejningsScooter);


            return Ok(createdScooter);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UdlejningsScooter udlejningsScooter)
        {
            if (udlejningsScooter == null)
            {
                return BadRequest("Scooter data mangler.");
            }
            var updatedScooter = await _udlejningsScooterService.UpdateUdlejningsScooterAsync(udlejningsScooter);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedId = await _udlejningsScooterService.RemoveUdlejningsScooterAsync(id);
            if (deletedId == 0)
            {
                return NotFound($"Ingen udlejnings-scooter fundet med ID {id}.");
            }
            return Ok();
        }
    }
}
