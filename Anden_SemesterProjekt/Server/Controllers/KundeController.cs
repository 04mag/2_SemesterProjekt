using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public List<Kunde>? GetKunder()
        {
            return _kundeService.ReadKunder();
        }

        [HttpGet("{tlfnummer}/{mærke}")]
        public List<Kunde>? GetKunder(string tlfnummer, string mærke)
        {
            return _kundeService.ReadKunder(tlfnummer, mærke);
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
                return new StatusCodeResult((int)HttpStatusCode.Conflict);
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
                return new StatusCodeResult((int)HttpStatusCode.OK);
            }
            else
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
        }

        [HttpDelete("{id}")]
        public StatusCodeResult DeleteKunde(int id)
        {
            bool deleted = _kundeService.DeleteKunde(id);
            
            if (deleted)
            {
                return new StatusCodeResult((int)HttpStatusCode.OK);
            }
            else
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
        }
    }
}
