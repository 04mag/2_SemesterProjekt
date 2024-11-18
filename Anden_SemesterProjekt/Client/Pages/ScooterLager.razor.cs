using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class ScooterLager
    {
        [Inject] private IJSRuntime JS { get; set; } // JavaScript runtime

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
            udlejningsScootere = await UdlejningsScooterService.GetUdlejningsScootere() ?? new List<UdlejningsScooter>();

            // Tildel mærker til scootere. Denne kode er nødvendig, da scootere ikke har mærke-navne-objekter,
           HentMærker();
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

                // Tildel data til nyUdlejningsScooter
                nyUdlejningsScooter.MærkeId = valgtScooterMærke.MærkeId;
                nyUdlejningsScooter.ErAktiv = true;
                nyUdlejningsScooter.ErTilgængelig = true;


                // Kald API for at gemme
                var response = await UdlejningsScooterService.AddUdlejningsScooter(nyUdlejningsScooter);

                if (response != null && response.IsSuccessStatusCode)
                {
                    successMessage = "Scooter oprettet med succes!";
                    udlejningsScootere = await UdlejningsScooterService.GetUdlejningsScootere();
                    HentMærker();

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
        private async Task EditScooter(UdlejningsScooter scooter)
        {
            nyUdlejningsScooter = scooter;
            valgtScooterMærkeId = scooter.MærkeId;
            var response = await UdlejningsScooterService.UpdateUdlejningsScooter(nyUdlejningsScooter);
            if (response.IsSuccessStatusCode)
            {
                udlejningsScootere.Add(scooter);
                HentMærker();
                StateHasChanged();
            }
        }
        private async Task DeleteScooter(UdlejningsScooter scooter)
        {
            // Vis en bekræftelsesdialog med JavaScript
            var confirmDelete = await JS.InvokeAsync<bool>("confirm", "Er du sikker på, at du vil slette denne scooter?");

            if (confirmDelete)
            {
                var response = await UdlejningsScooterService.DeleteUdlejningsScooter(scooter.ScooterId);
                if (response.IsSuccessStatusCode)
                {
                    udlejningsScootere.Remove(scooter);
                    HentMærker();
                    StateHasChanged();
                }
            }
        }
        private void HentMærker()
        {
            foreach (var scooter in udlejningsScootere)
            {
                if (scooter.Mærke == null)
                {
                    scooter.Mærke = mærker.FirstOrDefault(m => m.MærkeId == scooter.MærkeId);
                }
            }
        }
    }
}