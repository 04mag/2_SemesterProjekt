using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;


namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class ScooterLager
    {
        private UdlejningsScooter nyUdlejningsScooter = new UdlejningsScooter();
        private List<UdlejningsScooter> udlejningsScootere = new List<UdlejningsScooter>();
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
            udlejningsScootere = await UdlejningsScooterService.GetUdlejningsScootere();
        }

        
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

                // Kontrollér, om mærket blev fundet
                if (valgtScooterMærke == null)
                {
                    throw new InvalidOperationException("Det valgte mærke blev ikke fundet.");
                }
                
                nyUdlejningsScooter.Mærke = valgtScooterMærke;
               
                if (nyUdlejningsScooter.Mærke == null)
                {
                    nyUdlejningsScooter.Mærke = new Mærke();
                }
                nyUdlejningsScooter.Mærke.Mekanikere = valgtScooterMærke.Mekanikere?.ToList() ?? new List<Mekaniker>();
                // Tildel data til nyUdlejningsScooter.Mærke

                // Tildel øvrige værdier
                nyUdlejningsScooter.MærkeId = valgtScooterMærke.MærkeId;
                nyUdlejningsScooter.ErAktiv = true;
                nyUdlejningsScooter.ErTilgængelig = true;
                nyUdlejningsScooter.Udlejninger = new  List<Udlejning>();

                // Kald API for at gemme
                var response = await UdlejningsScooterService.AddUdlejningsScooter(nyUdlejningsScooter);
                if (response <= 0)
                {
                    throw new InvalidOperationException("Fejl ved oprettelse af udlejningsscooter.");
                }
                else
                {
                    Console.WriteLine(successMessage);
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
