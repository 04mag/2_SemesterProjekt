
using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class KundePage
    {
        private List<Kunde>? kunder;

        [Inject]
        public IKundeClientService KundeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            kunder = await KundeService.GetKunder();
        }

        private async Task OnKundeAddedHandler()
        {
            kunder = await KundeService.GetKunder();
        }

        private async Task OnEditKunde(Kunde kunde)
        {
            
        }

        private async Task OnDeleteKunde(Kunde kunde)
        {
            await KundeService.DeleteKunde(kunde.KundeId);
            kunder = await KundeService.GetKunder();
        }
    }
}
