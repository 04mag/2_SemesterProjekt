using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/ansat")]
    [ApiController]
    public class AnsatController : ControllerBase
    {
        private readonly IAnsatService _ansatService;

        public AnsatController(IAnsatService ansatService)
        {
            _ansatService = ansatService;
        }

        [HttpGet]
        public List<Mekaniker>? Get()
        {
            return _ansatService.ReadMekanikere();
        }

        [HttpGet("{id}")]
        public Mekaniker? Get(int id)
        {
            return _ansatService.ReadMekaniker(id);
        }
    }
}
