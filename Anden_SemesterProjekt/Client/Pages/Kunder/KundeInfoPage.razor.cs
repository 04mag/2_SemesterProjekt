using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Pages.Kunder
{
    public partial class KundeInfoPage
    {
        [Inject]
        public IKundeClientService KundeService { get; set; }

        [Parameter]
        public int KundeId { get; set; }

        public Kunde? KundeModel { get; set; }

        override protected async Task OnInitializedAsync()
        {
            var result = await KundeService.GetKunde(KundeId);

            if (result != null)
            {
                KundeModel = result;
            }
            else
            {
                KundeModel = new Kunde { KundeId = 0};
            }
        }
    }
}
