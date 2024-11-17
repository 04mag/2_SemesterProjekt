﻿using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Anden_SemesterProjekt.Client.Components.Kunder
{
    public partial class KundeCreateComponent
    {
        private Kunde kundeModel = new Kunde();
        private EditContext editContext;
        private bool isSubmitting = false;
        private string postnummerErrorMessage = "";
        private string byNavn = "";

        [Inject]
        public IKundeClientService KundeService { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(kundeModel);
        }

        private async Task HandleValidSubmit()
        {
            isSubmitting = true;

            By by = await KundeService.GetBy(kundeModel.Adresse.Postnummer);

            if (by == null)
            {
                postnummerErrorMessage = "Postnummeret findes ikke";
            }
            else
            {
                postnummerErrorMessage = "";
            }
            isSubmitting = false;
        }

        private async Task HandleInvalidSubmit()
        {
            By by = await KundeService.GetBy(kundeModel.Adresse.Postnummer);

            if (by == null)
            {
                postnummerErrorMessage = "Postnummeret findes ikke";
            }
            else
            {
                postnummerErrorMessage = "";
            }
        }

        private async Task<string> GetBynavn()
        {
            var result = await KundeService.GetBy(kundeModel.Adresse.Postnummer);

            if (result == null)
            {
                return "";
            }
            else
            {
                postnummerErrorMessage = "";
                return result.ByNavn;
            }
        }

        private async void PostnummerChanged()
        {
            byNavn = await GetBynavn();
        }
    }
}