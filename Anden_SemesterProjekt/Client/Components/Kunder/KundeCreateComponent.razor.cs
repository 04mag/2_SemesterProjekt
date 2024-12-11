using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

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

        [Parameter]
        public EventCallback<Kunde> OnKundeAdded { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Mekanikere = await AnsatService.GetMekanikere();
        }

        protected override void OnInitialized()
        {
            editContext = new EditContext(kundeModel);
        }

        private async Task HandleValidSubmit()
        {
            isSubmitting = true;

            bool checkPostnummer = await CheckPostnummer();

            if (checkPostnummer)
            {

                var result = await KundeService.PostKunde(kundeModel);

                if (result != null)
                {
                    await JS.InvokeVoidAsync("alert", "Kunde tilføjet");
                    await OnKundeAdded.InvokeAsync(result);
                    kundeModel = new Kunde();
                    Mekaniker = null;
                }
            }

            isSubmitting = false;
        }

        private async Task HandleInvalidSubmit()
        {
            await CheckPostnummer();
            await JS.InvokeVoidAsync("alert", "Felter er ikke udfyldt korrekt!");
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

        //mekaniker select
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
                kundeModel.MekanikerId = mekaniker.MekanikerId;
            }
            mekanikerSelectOpen = false;
        }

        //Kunde scooter del
        private void OnScooterAdded(KundeScooter scooter)
        {
            if (kundeModel.Scootere == null)
            {
                kundeModel.Scootere = new List<KundeScooter>();
            }
            kundeModel.Scootere.Add(scooter);
        }
        private void OnScooterRemoved(KundeScooter scooter)
        {
            if (kundeModel.Scootere != null)
            {
               kundeModel.Scootere.Remove(scooter);
            }
        }
    }
}
