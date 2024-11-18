using Anden_SemesterProjekt.Client.Services;
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
        public string? ByNavn { get; set; }


        [Inject]
        public IKundeClientService KundeService { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(kundeModel);
        }

        private async Task HandleValidSubmit()
        {
            isSubmitting = true;

            bool check = await CheckPostnummer();

            if (check)
            {
                kundeModel.MekanikerId = 1;

                Console.WriteLine("Making post call");

                var result = await KundeService.PostKunde(kundeModel);

                Console.WriteLine($"After post call.");

                if (result != null)
                {
                    Console.WriteLine($"ID: {result.KundeId}");
                    kundeModel = new Kunde();
                }
            }

            isSubmitting = false;
        }

        private async Task HandleInvalidSubmit()
        {
            await CheckPostnummer();
        }

        private async Task<bool> CheckPostnummer()
        {
            var result = await KundeService.GetBy(kundeModel.Adresse.Postnummer);

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
            kundeModel.TlfNumre.Add(tlfNummer);
        }

        private void OnTlfNummerInputRemove(TlfNummer tlfNummer)
        {
            kundeModel.TlfNumre.Remove(tlfNummer);
        }
    }
}
