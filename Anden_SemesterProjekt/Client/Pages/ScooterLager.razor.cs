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
        private UdlejningsScooter? valgtUdlejningsScooter = new UdlejningsScooter();
        private UdlejningsScooter? redigeretScooter = new UdlejningsScooter();
        private List<UdlejningsScooter>? udlejningsScootere = new List<UdlejningsScooter>();
        private List<Mærke> mærker = new List<Mærke>();
        private int? nyScooterMærkeId = new int();
        private int? valgtScooterMærkeId = new int();
        private bool detailsModal = false;
        private bool editModal = false;
        [Inject] public IMærkeClientService MærkeService { get; set; }
        [Inject] public IScooterClientService ScooterService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var mærkerResult = await MærkeService.GetMærker();

            if (mærkerResult != null)
            {
                mærker = mærkerResult;
            }

            var udlejningsScootereResult = await ScooterService.GetAllUdlejningsScootereAsync();

            if (udlejningsScootereResult != null)
            {
                udlejningsScootere = udlejningsScootereResult;
            }
            else
            {
                udlejningsScootere = new List<UdlejningsScooter>();
            }

            // Tildel mærker til scootere. Denne kode er nødvendig, da scootere ikke har mærke-navne-attributter,
            await HentMærker();
        }
        private async Task HandleValidSubmit()
        {
            try
            {
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
                var response = await ScooterService.CreateUdlejningsScooter(nyUdlejningsScooter);

                udlejningsScootere = await ScooterService.GetAllUdlejningsScootereAsync();
                await HentMærker();

                // Tving UI-opdatering
                StateHasChanged();
                nyUdlejningsScooter = new UdlejningsScooter();
                nyScooterMærkeId = null;

            }
            catch (Exception ex)
            {
                var errorBox = await JS.InvokeAsync<string>("alert", ex.Message);
            }
        }
        private void ScooterDetaljer(UdlejningsScooter scooter)
        {
            foreach (var s in udlejningsScootere)
            {
                if (s.ScooterId == scooter.ScooterId)
                {   valgtUdlejningsScooter = scooter;
                    detailsModal = true;
                    StateHasChanged();
                }
                else
                {
                    detailsModal = false;
                    StateHasChanged();
                }
            }
            detailsModal = true;
        }
        private void EditScooter(UdlejningsScooter scooter)
        {
            valgtUdlejningsScooter = scooter;
            redigeretScooter = new UdlejningsScooter
            {
                ScooterId = scooter.ScooterId,
                Stelnummer = scooter.Stelnummer,
                Registreringsnummer = scooter.Registreringsnummer,
                MærkeId = scooter.MærkeId,
                ErAktiv = scooter.ErAktiv,
                ErTilgængelig = scooter.ErTilgængelig,
              };
            
            editModal = true;
            StateHasChanged();
        }

        private void CloseModal()
        {
            detailsModal = false;
        }
        private async Task CloseEditModal()
        {
            editModal = false;
        }


        private async Task UpdateScooter()
        {
            valgtUdlejningsScooter.MærkeId = valgtScooterMærkeId.Value;
            var response = await ScooterService.UpdateScooter(redigeretScooter);
            if (response > 0)
            {
                var successBox = await JS.InvokeAsync<string>("alert", "Scooteren er opdateret.");
                detailsModal = false;
                udlejningsScootere = await ScooterService.GetAllUdlejningsScootereAsync();
                HentMærker();
                detailsModal = true;
                editModal = false;
                detailsModal = false;
            }
        }
        private async Task DeleteScooter(UdlejningsScooter scooter)
        {
            // Vis en bekræftelsesdialog med JavaScript
            var confirmDelete = await JS.InvokeAsync<bool>("confirm", "Er du sikker på, at du vil slette denne scooter?");
            if (confirmDelete)
            {
                var response = await ScooterService.DeleteScooter(scooter.ScooterId);
                if (response > 0)
                {
                    udlejningsScootere.Remove(scooter);
                    await HentMærker();
                   editModal = false;

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