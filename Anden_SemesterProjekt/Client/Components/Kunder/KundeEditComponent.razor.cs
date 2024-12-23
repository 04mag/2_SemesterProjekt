﻿using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Components.Kunder
{
    public partial class KundeEditComponent
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private IJSRuntime JS { get; set; }

        [Inject]
        public IKundeClientService KundeService { get; set; }

        [Parameter, EditorRequired]
        public Kunde KundeModel { get; set; } = new Kunde();

        public EditContext EditContext { get; set; }

        private string postnummerErrorMessage = "";
        public string? ByNavn { get; set; }

        private bool isSubmitting = false;

        protected override void OnInitialized()
        {
            EditContext = new EditContext(KundeModel);

            if (KundeModel.TilknyttetMekaniker != null)
            {
                Mekaniker = KundeModel.TilknyttetMekaniker;
            }

            if (KundeModel.Adresse.By != null)
            {
                ByNavn = KundeModel.Adresse.By.ByNavn;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Mekanikere = await AnsatService.GetMekanikere();
        }

        private async void HandleValidSubmit()
        {
            isSubmitting = true;

            bool checkPostnummer = await CheckPostnummer();

            if (checkPostnummer)
            {
                KundeModel.TilknyttetMekaniker = null;
                KundeModel.Adresse.By = null;

                var result = await KundeService.PutKunde(KundeModel);

                if (result.IsSuccessStatusCode)
                {
                    await JS.InvokeVoidAsync("alert", "Nye kundeoplysninger blev gemt.");
                    isSubmitting = false;
                    NavigationManager.NavigateTo("/kunder");

                }
                else
                {
                    await JS.InvokeVoidAsync("alert", "Der skete en fejl under opdatering af kunden.");
                    isSubmitting = false;
                }
            }

            isSubmitting = false;
        }

        private async void HandleInvalidSubmit()
        {
            await JS.InvokeVoidAsync("alert", "Felter er ikke udfyldt korrekt!");
        }

        private async Task<bool> CheckPostnummer()
        {
            var result = await KundeService.GetBy(KundeModel.Adresse.Postnummer);

            if (result == null)
            {
                ByNavn = null;
                postnummerErrorMessage = "Postnummeret findes ikke.";
                return false;
            }
            else
            {
                postnummerErrorMessage = "";
                ByNavn = result.ByNavn;
                return true;
            }
        }

        private void OnTlfNummerInputSuccess(TlfNummer tlfNummer)
        {
            KundeModel.TlfNumre.Add(tlfNummer);
        }

        private void OnTlfNummerInputRemove(TlfNummer tlfNummer)
        {
            KundeModel.TlfNumre.Remove(tlfNummer);
        }


        //Mekaniker select del
        [Inject]
        public IAnsatClientService AnsatService { get; set; }
        public List<Mekaniker>? Mekanikere { get; set; } = new List<Mekaniker>();
        public Mekaniker? Mekaniker { get; set; } = null;
        private bool mekanikerSelectOpen = false;

        private void OnMekanikerSelected(Mekaniker mekaniker)
        {
            if (mekaniker != null)
            {
                Mekaniker = mekaniker;
                KundeModel.MekanikerId = mekaniker.MekanikerId;
            }
            mekanikerSelectOpen = false;
        }

        private void OnMekanikerRemove()
        {
            Mekaniker = null;
            KundeModel.MekanikerId = null;
        }

        //Kunde scooter del
        private void OnScooterAdded(KundeScooter scooter)
        {
            if (KundeModel.Scootere == null)
            {
                KundeModel.Scootere = new List<KundeScooter>();
            }
            KundeModel.Scootere.Add(scooter);
        }
        private void OnScooterRemoved(KundeScooter scooter)
        {
            if (KundeModel.Scootere != null)
            {
                KundeModel.Scootere.Remove(scooter);
            }
        }
    }
}
