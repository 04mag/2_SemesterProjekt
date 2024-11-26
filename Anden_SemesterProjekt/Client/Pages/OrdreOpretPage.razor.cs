using Anden_SemesterProjekt.Shared.Models;
using Anden_SemesterProjekt.Client.Components;
using Microsoft.AspNetCore.Components;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.JSInterop;
using System.Text;

namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class OrdreOpretPage
    {
        //Inject af JS
        [Inject]
        private IJSRuntime JS { get; set; }

        //Inject af NavigationManager
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        //Inject af services
        [Inject]
        public IOrdreClientService OrdreService { get; set; }
        [Inject]
        public IKundeClientService KundeService { get; set; }


        //Modeller til oprettelse af ordren
        public Ordre OrdreModel { get; set; } = new Ordre();

        public Kunde? KundeModel { get; set; }
        public KundeScooter? KundeScooterModel { get; set; }
        public Mekaniker? MekanikerModel { get; set; }
        public UdlejningsScooter? UdlejningsScooterModel { get; set; }

        //Lister til valg af kunde, mekaniker, scootere osv.
        public List<Kunde> Kunder { get; set; } = new List<Kunde>();

        //Bools til at vise/hide components
        private bool showKundeSelect = false;

        protected override async Task OnInitializedAsync()
        {
            //Henter liste af kunder
            var kunder = await KundeService.GetKunder();
            if (kunder != null)
            {
                Kunder = kunder;
            }


        }

        private void OpretOrdre()
        {
            if (KundeScooterModel != null) OrdreModel.KundeScooterId = KundeScooterModel.ScooterId;
            if (MekanikerModel != null) OrdreModel.MekanikerId = MekanikerModel.MekanikerId;
            if (UdlejningsScooterModel != null)
            {
                OrdreModel.Udlejning = new Udlejning
                {
                    UdlejningsScooterId = UdlejningsScooterModel.ScooterId,
                    StartDato = OrdreModel.StartDato,
                    SlutDato = OrdreModel.SlutDato
                };
            }
        }

        private void OnKundeSelected(Kunde kunde)
        {
            KundeModel = kunde;
            showKundeSelect = false;
        }

        private async Task OnKundeRemoved()
        {
            var confirmRemove = await JS.InvokeAsync<bool>("confirm", "Er du sikker på, at du vil ændre kunden knyttet til ordren?\nDette vil åbne en ny ordre!");

            if (confirmRemove)
            {
                NavigateToOpretOrdre();
            }
        }


        //Navigationsmetoder
        private void NavigateToKundePage()
        {
            NavigationManager.NavigateTo("/kunder/opret");
        }

        private void NavigateToOpretOrdre()
        {
            NavigationManager.Refresh();
        }
    }

}
