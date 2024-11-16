using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public List<Mærke>? Get()
        {
            return _mærkeService.ReadMærke();
        }

        [HttpGet("{id}")]
        public Mærke? Get(int id)
        {
            return _mærkeService.ReadMærke(id);
        }

        [HttpPost]
        public int Post(Mærke mærke)
        {
            return _mærkeService.CreateMærke(mærke);
        }
        [HttpPut]
        public int Put(Mærke mærke)
        {
            return _mærkeService.UpdateMærke(mærke);
        }
        [HttpDelete]
        public int Delete(int id)
        {
            return _mærkeService.DeleteMærke(id);
        }

    }
}
