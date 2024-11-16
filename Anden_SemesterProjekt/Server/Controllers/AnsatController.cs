using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/mekaniker")]
    [ApiController]
    public class AnsatController : ControllerBase
    {
        private readonly IAnsatService _ansatService;

        public AnsatController(IAnsatService ansatService)
        {
            _ansatService = ansatService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var mekanikere = _ansatService.ReadMekanikere();

            if (mekanikere == null)
            {
                return NotFound();
            }

            return Ok(mekanikere);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var mekaniker = _ansatService.ReadMekaniker(id);

            if (mekaniker == null)
            {
                return NotFound();
            }
            return Ok(mekaniker);
        }
    }
}
