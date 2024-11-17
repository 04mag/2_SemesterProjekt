using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Components.Scootere
{
    public partial class ScooterHåndtering
    {
        private UdlejningsScooter nyUdlejningsScooter = new UdlejningsScooter();
        private List<UdlejningsScooter> udlejningsScootere = new List<UdlejningsScooter>();
        private string? successMessage;
        private string? errorMessage;
        private List<Mærke> mærker = new List<Mærke>();
        private int? valgtScooterMærkeId = new int();
        [Inject] public IMærkeClientService MærkeService { get; set; }
        [Inject] public IUdlejningsScooterClientService UdlejningsScooterService { get; set; }
        private async Task HandleValidSubmit()
        {
            try
            {
                successMessage = "Scooter oprettet med succes!";
                errorMessage = null;

                if (valgtScooterMærkeId == null)
                {
                    throw new InvalidOperationException("Valgt scooter mærke ID er null.");
                }

                // Find det valgte mærke
                var valgtScooterMærke = mærker.FirstOrDefault(m => m.MærkeId == valgtScooterMærkeId);

                // Tildel data til nyUdlejningsScooter
                nyUdlejningsScooter.MærkeId = valgtScooterMærke.MærkeId;
                nyUdlejningsScooter.ErAktiv = true;
                nyUdlejningsScooter.ErTilgængelig = true;


                // Kald API for at gemme
                var response = await UdlejningsScooterService.AddUdlejningsScooter(nyUdlejningsScooter);

                if (response != null && response.IsSuccessStatusCode)
                {
                    successMessage = "Scooter oprettet med succes!";
                    udlejningsScootere.Add(nyUdlejningsScooter);
                   

                    // Eller, opret en ny liste, der inkluderer den nye scooter
                    // udlejningsScootere = udlejningsScootere.Concat(new [] { nyUdlejningsScooter }).ToList();

                    // Tving UI-opdatering
                    StateHasChanged();
                    nyUdlejningsScooter = new UdlejningsScooter();
                    valgtScooterMærkeId = null;
                }
                else
                {
                    throw new InvalidOperationException("API oprettelsen mislykkedes.");
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
