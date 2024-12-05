using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/ordre")]
    [ApiController]
    public class OrdreController : ControllerBase
    {
        private readonly IOrdreService _ordreService;

        public OrdreController(IOrdreService ordreService)
        {
            _ordreService = ordreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ordre>>> GetOrdrer()
        {
            var ordre = await _ordreService.GetOrdrerAsync();
            if (ordre == null || ordre.Count == 0)
            {
                return NotFound("Ingen ordre fundet.");
            }
            return Ok(ordre);
        }

        [HttpGet("kunde/{kundeId}")]
        public async Task<ActionResult<List<Ordre>>> GetKundeOrdrer(int kundeId)
        {
            var ordre = await _ordreService.GetOrdrerAsync(kundeId);
            if (ordre == null || ordre.Count == 0)
            {
                return NotFound("Ingen ordre fundet.");
            }
            return Ok(ordre);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ordre>> GetOrdre(int id)
        {
            var ordre = await _ordreService.GetOrdreAsync(id);
            if (ordre == null)
            {
                return NotFound($"Ingen ordre fundet med ID {id}.");
            }
            return Ok(ordre);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Ordre ordre)
        {
            if (ordre == null)
            {
                return BadRequest("Ordre data mangler.");
            }

            var id = await _ordreService.AddOrdreAsync(ordre);

            if (id == -1)
            {
                return Conflict();
            }
            else
            {
                //Henter den nye kunde og tildeler den det nye id.
                return CreatedAtAction(nameof(GetOrdre), new { id = id }, ordre);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> Put(Ordre ordre)
        {
            if (ordre == null)
            {
                return BadRequest("Ordre data mangler.");
            }

            var rowsChanged = await _ordreService.UpdateOrdreAsync(ordre);
            return Ok($"Rows changed: {rowsChanged}");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var rowsAffected = await _ordreService.DeleteOrdreAsync(id);
            if (rowsAffected == 0)
            {
                return NotFound($"Ingen ordre fundet med ID {id}.");
            }
            return Ok(rowsAffected);
        }
    }
}
