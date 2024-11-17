using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/mærke")]
    [ApiController]
    public class MærkeController : ControllerBase
    {
        private readonly IMærkeService _mærkeService;

        public MærkeController(IMærkeService mærkeService)
        {
            _mærkeService = mærkeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mærke>>> Get()
        {
            var mærker = await _mærkeService.GetAllMærkerAsync();
            if (mærker == null || mærker.Count == 0)
            {
                return NotFound("Ingen mærker fundet.");
            }
            return Ok(mærker);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mærke>> Get(int id)
        {
            var mærke = await _mærkeService.GetMærkeAsync(id);
            if (mærke == null)
            {
                return NotFound($"Ingen mærke fundet med ID {id}.");
            }
            return Ok(mærke);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Mærke mærke)
        {
            if (mærke == null)
            {
                return BadRequest("Mærke data mangler.");
            }

            var id = await _mærkeService.AddMærkeAsync(mærke);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> Put(Mærke mærke)
        {
            if (mærke == null)
            {
                return BadRequest("Mærke data mangler.");
            }

            var id = await _mærkeService.UpdateMærkeAsync(mærke);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var deletedId = await _mærkeService.DeleteMærkeAsync(id);
            if (deletedId == 0)
            {
                return NotFound($"Ingen mærke fundet med ID {id}.");
            }
            return Ok(deletedId);
        }
    }
}
