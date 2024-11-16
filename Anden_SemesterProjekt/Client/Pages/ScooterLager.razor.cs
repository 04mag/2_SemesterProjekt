using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;


namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class ScooterLager
    {
        private UdlejningsScooter nyUdlejningsScooter = new UdlejningsScooter();
        private string? newPhone;
        private string? successMessage;
        private string? errorMessage;
        private List<Mærke> mærker = new List<Mærke>();
        private int? valgtScooterMærkeId;
        [Inject]
        public IMærkeClientService MærkeService { get; set; }
        [Inject]
        public IUdlejningsScooterClientService UdlejningsScooterService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            mærker = await MærkeService.GetMærker();
        }

        private async Task HandleValidSubmit()
        {
            successMessage = "Kunde oprettet med succes!";
            errorMessage = null;
            Console.WriteLine(successMessage);
            nyUdlejningsScooter.ScooterMærke = mærker.FirstOrDefault(m => m.MærkeId == valgtScooterMærkeId); // Tildeler ScooterMærke til den valgte mærke, som er valgt i dropdown menuen baseret på mærkeId
            nyUdlejningsScooter.ErAktiv= true;
            nyUdlejningsScooter.ErTilgængelig = true;
            nyUdlejningsScooter.Udlejninger = new List<Udlejning>();
            var response = await UdlejningsScooterService.AddUdlejningsScooter(nyUdlejningsScooter);
        }
    }


}
