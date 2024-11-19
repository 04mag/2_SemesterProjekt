using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Pages.Kunder
{
    public partial class KundeEditPage
    {
        [Inject]
        public IKundeClientService KundeService { get; set; }

        [Parameter]
        public int KundeId { get; set; }

        public Kunde? Kunde { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Kunde = await KundeService.GetKunde(KundeId);
        }
    }
}
