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
        public IActionResult GetBy(int postnummer)
        {
            var by = _kundeService.GetBy(postnummer);

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
        public IActionResult GetKunder()
        {
            var kunder = _kundeService.ReadKunder();

            if (kunder == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(kunder);
            }
        }

        [HttpGet("{tlfnummer}/{mærke}")]
        public IActionResult GetKunder(string tlfnummer, string mærke)
        {
            var kunder = _kundeService.ReadKunder(tlfnummer, mærke);

            if (kunder == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(kunder);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetKunde(int id)
        {
            var kunde = _kundeService.ReadKunde(id);

            if (kunde == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(kunde);
            }
        }

        [HttpPost]
        public IActionResult PostKunde(Kunde kunde)
        {
            int id = _kundeService.CreateKunde(kunde);

            if (id == -1)
            {
                return Conflict();
            }
            else
            {
                return CreatedAtAction(nameof(GetKunde), new { id = id }, kunde);
            }
        }

        [HttpPut]
        public StatusCodeResult PutKunde(Kunde kunde)
        {
            bool updated = _kundeService.UpdateKunde(kunde);

            if (updated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public StatusCodeResult DeleteKunde(int id)
        {
            bool deleted = _kundeService.DeleteKunde(id);
            
            if (deleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
