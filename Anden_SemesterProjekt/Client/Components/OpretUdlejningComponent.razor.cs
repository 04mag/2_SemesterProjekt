using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components
{
    public partial class OpretUdlejningComponent
    {
        Udlejning nyUdlejning = new Udlejning();
        UdlejningsScooter udlejningsScooter = new UdlejningsScooter();
        List<UdlejningsScooter>? udlejningsScootere = new List<UdlejningsScooter>();
        private int SamletKmPris = new int();
        [Inject] private IUdlejningClientService UdlejningClientService { get; set; }
       [Inject] private IScooterClientService ScooterClientService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await ScooterClientService.GetAllUdlejningsScootereAsync();
            udlejningsScootere = result.Where(x => x.ErTilgængelig).ToList();

        }
        public async Task OpretUdlejning()

        {
            //nyUdlejning.UdlejningsScooterId = nyUdlejning.Ordre.UdlejningsScooterId.Value;
       
            nyUdlejning.OrdreId = nyUdlejning.Ordre.OrdreId;
            await UdlejningClientService.AddUdlejningAsync(nyUdlejning);
        }
        public async Task HandleValidSubmit()
        {
            await OpretUdlejning();
        }

    }
}
