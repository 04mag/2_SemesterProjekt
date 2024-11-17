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
        private string? successMessage;
        private string? errorMessage;
        private List<Mærke> mærker = new List<Mærke>();
        private int? valgtScooterMærkeId = new int();
        [Inject] public IMærkeClientService MærkeService { get; set; }
        [Inject] public IUdlejningsScooterClientService UdlejningsScooterService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            mærker = await MærkeService.GetMærker();
            udlejningsScootere = await UdlejningsScooterService.GetUdlejningsScootere();
            foreach (var scooter in udlejningsScootere)
            {
                if (scooter.Mærke == null)
                {
                    scooter.Mærke = mærker.FirstOrDefault(m => m.MærkeId == scooter.MærkeId);
                }
            }
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

                // Tildel data til nyUdlejningsScooter
                //nyUdlejningsScooter.Mærke = valgtScooterMærke;
                nyUdlejningsScooter.MærkeId = valgtScooterMærkeId.Value;
                nyUdlejningsScooter.ErAktiv = true;
                nyUdlejningsScooter.ErTilgængelig = true;
                //nyUdlejningsScooter.Udlejninger = new List<Udlejning>();

                // Kald API for at gemme
                var response = await UdlejningsScooterService.AddUdlejningsScooter(nyUdlejningsScooter);
                if (response == null)
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
