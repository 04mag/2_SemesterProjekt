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
        private List<Mærke>? mærker = new List<Mærke>();
        private int? valgtMærkeId;
        [Inject]
        public IMærkeClientService MærkeService { get; set; }
        [Inject]
        public IUdlejningsScooterClientService UdlejningsScooterService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            mærker = await MærkeService.GetMærker();
        }

        private void UpdateMærke()
        {
            // Find mærket baseret på valgtMærkeId
            var valgtMærke = mærker.FirstOrDefault(m => m.MærkeId == valgtMærkeId);

            if (valgtMærke != null)
            {
                // Tildel det fundne mærke til nyUdlejningsScooter.Mærke
                nyUdlejningsScooter.Mærke = valgtMærke;
            }
            else
            {
                // Hvis intet mærke blev fundet, kan vi sætte Mærke til null eller en tom værdi
                nyUdlejningsScooter.Mærke = null;
            }
        }
        private async Task HandleValidSubmit()
        {
            successMessage = "Kunde oprettet med succes!";
            errorMessage = null;
            Console.WriteLine(successMessage);
            nyUdlejningsScooter.Mærke = mærker.FirstOrDefault(m => m.MærkeId == valgtMærkeId);
            nyUdlejningsScooter.ErAktiv= true;
            nyUdlejningsScooter.ErTilgængelig = true;
            nyUdlejningsScooter.Udlejninger = new List<Udlejning>();
            nyUdlejningsScooter.Mærke.Mekanikere = null;
            nyUdlejningsScooter.Mærke.Scootere = null;

            if (nyUdlejningsScooter.Mærke != null)
            {
                var response = await UdlejningsScooterService.AddUdlejningsScooter(nyUdlejningsScooter);
                if (response != -1)
                { 
                    Console.WriteLine("Scooter added successfully");
                }
                else
                {
                    Console.WriteLine("There was an error adding the scooter");
                }
            }
            else
            {
                Console.WriteLine("Mærke er ikke valgt");
            }
        }

        private async Task ButtonClickHandler()
        {
            await UdlejningsScooterService.AddUdlejningsScooter(nyUdlejningsScooter);

        }

    }


}
