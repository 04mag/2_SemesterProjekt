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

        [HttpPost]
        public int PostKunde(Kunde kunde)
        {
            return _kundeService.CreateKunde(kunde);
        }
    }
}
