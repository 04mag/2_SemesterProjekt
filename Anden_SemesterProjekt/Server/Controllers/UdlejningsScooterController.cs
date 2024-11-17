using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anden_SemesterProjekt.Server.Controllers
{
    [Route("api/udlejningsscooter")]
    [ApiController]
    public class UdlejningsScooterController : ControllerBase
    {
        private readonly IUdlejningsScooterService _udlejningsScooterService;

        public UdlejningsScooterController(IUdlejningsScooterService udlejningsScooterService)
        {
            _udlejningsScooterService = udlejningsScooterService;
        }

        [HttpGet]
        public List<UdlejningsScooter>? Get()
        {
            return _udlejningsScooterService.ReadUdlejningsScootere();
        }

        [HttpGet("{id}")]
        public UdlejningsScooter? Get(int id)
        {
            return _udlejningsScooterService.ReadUdlejningsScooter(id);
        }

        [HttpPost]
        public int Post([FromBody] UdlejningsScooter udlejningsScooter)
        {
            return _udlejningsScooterService.CreateUdlejningsScooter(udlejningsScooter);
        }

        [HttpPut]
        public int Put(UdlejningsScooter udlejningsScooter)
        {
            return _udlejningsScooterService.UpdateUdlejningsScooter(udlejningsScooter);
        }

        [HttpDelete]
        public int Delete(int id)
        {
            return _udlejningsScooterService.DeleteUdlejningsScooter(id);
        }
    }
}