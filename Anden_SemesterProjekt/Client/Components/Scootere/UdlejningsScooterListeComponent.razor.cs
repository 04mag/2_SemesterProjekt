using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Components.Scootere
{
    public partial class UdlejningsScooterListeComponent
    {
        [Inject] private IJSRuntime JS { get; set; } // JavaScript runtime

        private UdlejningsScooter nyUdlejningsScooter = new UdlejningsScooter();
        private UdlejningsScooter valgtUdlejningsScooter = new UdlejningsScooter();
        private UdlejningsScooter redigeretScooter;
        private List<Mærke> mærker = new List<Mærke>();
        private int? nyScooterMærkeId = new int();
        private int? valgtScooterMærkeId = new int();
        private bool detailsModal = false;
        private bool editModal = false;
        [Inject] public IMærkeClientService MærkeService { get; set; }
        [Inject] public IScooterClientService UdlejningsScooterService { get; set; }
        [Parameter] public List<UdlejningsScooter> UdlejningsScootere { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var mærkerResult = await MærkeService.GetMærker();

            if (mærkerResult != null)
            {
                mærker = mærkerResult;
            }

            var udlejningsScootereResult = await UdlejningsScooterService.GetAllUdlejningsScootereAsync();

            if (udlejningsScootereResult != null)
            {
                UdlejningsScootere = udlejningsScootereResult;
            }

            // Tildel mærker til scootere. Denne kode er nødvendig, da scootere ikke har mærke-navne-objekter,
            await HentMærker();
        }
        
        private void ScooterDetaljer(UdlejningsScooter scooter)
        {
            foreach (var s in UdlejningsScootere)
            {
                if (s.ScooterId == scooter.ScooterId)
                {
                    valgtUdlejningsScooter = scooter;
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
            var response = await UdlejningsScooterService.UpdateScooter(redigeretScooter);
            if (response != null)
            {
                var successBox = await JS.InvokeAsync<string>("alert", "Scooteren er opdateret.");
                detailsModal = false;
                UdlejningsScootere = await UdlejningsScooterService.GetAllUdlejningsScootereAsync();
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
                var response = await UdlejningsScooterService.DeleteScooter(scooter.ScooterId);
                if (response != null)
                {
                    UdlejningsScootere.Remove(scooter);
                    await HentMærker();
                    editModal = false;
                    detailsModal = false;
                    JS.InvokeVoidAsync("alert", "Scooteren er slettet.");

                    nyUdlejningsScooter = new UdlejningsScooter();
                    StateHasChanged();
                }
            }
        }
        private async Task HentMærker()
        {
            foreach (var scooter in UdlejningsScootere)
            {
                if (scooter.Mærke == null)
                {
                    scooter.Mærke = mærker.FirstOrDefault(m => m.MærkeId == scooter.MærkeId);
                }
            }
        }
        private async Task HandleChildChanged()
        {
            UdlejningsScootere = await UdlejningsScooterService.GetAllUdlejningsScootereAsync();

            StateHasChanged();
        }

    }
}