using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public Kunde? GetKunde(int id)
        {
            return _kundeService.ReadKunde(id);
        }

        [HttpPost]
        public int PostKunde(Kunde kunde)
        {
            return _kundeService.CreateKunde(kunde);
        }

        [HttpPut]
        public bool PutKunde(Kunde kunde)
        {
            return _kundeService.UpdateKunde(kunde);
        }

        [HttpDelete("{id}")]
        public bool DeleteKunde(int id)
        {
            return _kundeService.DeleteKunde(id);
        }
    }
}
