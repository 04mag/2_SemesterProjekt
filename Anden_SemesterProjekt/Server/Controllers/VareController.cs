using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory; 

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/varer")]
    [ApiController]
    public class VareController : ControllerBase
    {
        private readonly IVareService _vareService;
        public VareController(IVareService vareService)
        {
            _vareService = vareService;
        }

        [HttpPost]
        public IActionResult PostVare(Vare vare)
        {
            int id = _vareService.CreateVare(vare);

            if (vare == null) //Kan denne være Null med ApiController?
            {
                return BadRequest();
            }
            else
            {
                return CreatedAtAction(nameof(GetVare), new { id = id }, vare);
            }
        }

        [HttpPost("Ydelse")]
        public IActionResult PostVare(Ydelse vare)
        {
            int id = _vareService.CreateVare(vare);

            if (vare == null) //Kan denne være Null med ApiController?
            {
                return BadRequest();
            }
            else
            {
                return CreatedAtAction(nameof(GetVare), new { id = id }, vare);
            }
        }

        [HttpGet("VarerOgYdelser")]
        public IActionResult GetAktiveVarerOgYdelser()
        {
            var varer = _vareService.ReadAktiveVarerOgYdelser();

            if (varer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(varer);
            }
        }

        [HttpGet("Varer")]
        public IActionResult GetAktiveVarer()
        {
            var varer = _vareService.ReadAktiveVarer();

            if (varer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(varer);
            }
        }

        [HttpGet("Ydelser")]
        public IActionResult GetAktiveYdelser()
        {
            var ydelser = _vareService.ReadAktiveYdelser();
            if (ydelser == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ydelser);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetVare(int id)
        {
            var vare = _vareService.ReadVare(id);

            if (vare == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vare);
            }
        }

        [HttpPut]
        public IActionResult PutVare(Vare vare) 
        {
            bool updated = _vareService.UpdateVare(vare);
            
            if (updated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("Ydelse")]
        public IActionResult PutVare(Ydelse vare)
        {
            bool updated = _vareService.UpdateVare(vare);
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
        public IActionResult DeleteVare(int id)
        {
            bool deleted = _vareService.DeleteVare(id);
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
