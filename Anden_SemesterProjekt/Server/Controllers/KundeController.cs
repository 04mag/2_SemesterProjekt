using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/kunder")]
    [ApiController]
    public class KundeController : ControllerBase
    {
        private readonly IKundeService _kundeService;
        public KundeController(IKundeService kundeService)
        {
            _kundeService = kundeService;
        }

        [HttpGet("by/{postnummer}")]
        public async Task<IActionResult> GetBy(string postnummer)
        {
            var by = await _kundeService.GetBy(postnummer);

            if (by == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(by);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetKunder()
        {
            try
            {
                var kunder = await _kundeService.ReadKunder();

                if (kunder == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(kunder);
                }
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKunde(int id)
        {
            try
            {
                var kunde = await _kundeService.ReadKunde(id);

                if (kunde == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(kunde);
                }
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostKunde(Kunde kunde)
        {
            try
            {
                int id = await _kundeService.CreateKunde(kunde);

                if (id > 0)
                {
                    //Henter den nye kunde og tildeler den det nye id.
                    return CreatedAtAction(nameof(GetKunde), new { id = id }, kunde);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutKunde(Kunde kunde)
        {
            try
            {
                bool updated = await _kundeService.UpdateKunde(kunde);

                if (updated)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKunde(int id)
        {
            try
            {
                bool deleted = await _kundeService.DeleteKunde(id);

                if (deleted)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
