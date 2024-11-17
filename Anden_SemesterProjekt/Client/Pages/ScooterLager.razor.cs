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
            try
            {
                successMessage = "Scooter oprettet med succes!";
                errorMessage = null;
                Console.WriteLine(successMessage);

                if (valgtScooterMærkeId == null)
                {
                    throw new InvalidOperationException("Valgt scooter mærke ID er null.");
                }

                nyUdlejningsScooter.MærkeId = valgtScooterMærkeId.Value;
                nyUdlejningsScooter.ErAktiv = true;
                nyUdlejningsScooter.ErTilgængelig = true;
                nyUdlejningsScooter.Udlejninger = new List<Udlejning>();
                

                var response = await UdlejningsScooterService.AddUdlejningsScooter(nyUdlejningsScooter);
                if (response <= 0)
                {
                    throw new InvalidOperationException("Fejl ved oprettelse af udlejnings scooter.");
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Fejl: {ex.Message}";
                Console.WriteLine(errorMessage);
            }
        }
    }


}
