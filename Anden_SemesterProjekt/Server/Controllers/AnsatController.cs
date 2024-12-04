using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/ansatte")]
    [ApiController]
    public class AnsatController : ControllerBase
    {
        private readonly IAnsatService _ansatService;

        public AnsatController(IAnsatService ansatService)
        {
            _ansatService = ansatService;
        }

        [HttpGet("mekanikere")]
        public async Task<IActionResult> Get()
        {
            var mekanikere = await _ansatService.ReadMekanikere();

            if (mekanikere == null)
            {
                return NotFound();
            }

            return Ok(mekanikere);
        }

        [HttpGet("mekanikere/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mekaniker = await _ansatService.ReadMekaniker(id);

            if (mekaniker == null)
            {
                return NotFound();
            }
            return Ok(mekaniker);
        }
    }
}
