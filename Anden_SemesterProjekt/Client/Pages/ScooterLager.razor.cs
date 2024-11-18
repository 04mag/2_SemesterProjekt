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
        private UdlejningsScooter valgtUdlejningsScooter = new UdlejningsScooter();
        private List<UdlejningsScooter> udlejningsScootere = new List<UdlejningsScooter>();
        private string? successMessage;
        private string? errorMessage;
        private List<Mærke> mærker = new List<Mærke>();
        private int? nyScooterMærkeId = new int();
        private int? valgtScooterMærkeId = new int();
        private bool showModal = false;
        private bool editModal = false;
        [Inject] public IMærkeClientService MærkeService { get; set; }
        [Inject] public IUdlejningsScooterClientService UdlejningsScooterService { get; set; }
        protected override async Task OnInitializedAsync()
        {

            var mærkerResult = await MærkeService.GetMærker();

            if (mærkerResult != null)
            {
                mærker = mærkerResult;
            }

            var udlejningsScootereResult = await UdlejningsScooterService.GetUdlejningsScootere();

            if (udlejningsScootereResult != null)
            {
                udlejningsScootere = udlejningsScootereResult;
            }

            // Tildel mærker til scootere. Denne kode er nødvendig, da scootere ikke har mærke-navne-objekter,
             await HentMærker();
        }
        private async Task HandleValidSubmit()
        {
            try
            {
                successMessage = "Scooter oprettet med succes!";
                errorMessage = null;

                if (nyScooterMærkeId == null)
                {
                    throw new InvalidOperationException("Valgt scooter mærke ID er null.");
                }

                // Find det valgte mærke
                var valgtScooterMærke = mærker.FirstOrDefault(m => m.MærkeId == nyScooterMærkeId);

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
                    await HentMærker();

                    // Tving UI-opdatering
                    StateHasChanged();
                    nyUdlejningsScooter = new UdlejningsScooter();
                    nyScooterMærkeId = null;
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
        private void ScooterDetaljer(UdlejningsScooter scooter)
        {
            foreach (var s in udlejningsScootere)
            {
                if (s.ScooterId == scooter.ScooterId)
                {   valgtUdlejningsScooter = scooter;
                    showModal = true;
                    StateHasChanged();
                }
                else
                {
                    showModal = false;
                    StateHasChanged();
                }
            }
            showModal = true;
        }
        private void EditScooter(UdlejningsScooter scooter)
        {
            valgtScooterMærkeId = valgtUdlejningsScooter.MærkeId;
            editModal = true;
            StateHasChanged();
        }

        private void CloseModal()
        {
            showModal = false;
        }
        private void CloseEditModal()
        {
            editModal = false;
        }


        private async Task UpdateScooter()
        {
            var response = await UdlejningsScooterService.UpdateUdlejningsScooter(valgtUdlejningsScooter);
            if (response.IsSuccessStatusCode)
            {
               
                StateHasChanged();
                editModal = false;
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
                    await HentMærker();
                    showModal = false;
                    nyUdlejningsScooter = new UdlejningsScooter();
                    StateHasChanged();
                }
            }
        }
        private async Task HentMærker()
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