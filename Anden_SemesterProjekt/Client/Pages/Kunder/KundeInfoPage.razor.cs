using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Anden_SemesterProjekt.Client.Pages.Kunder
{
    public partial class KundeInfoPage
    {
        [Inject]
        public IKundeClientService KundeService { get; set; }

        [Inject]
        public IOrdreClientService OrdreService { get; set; }

        [Parameter]
        public int KundeId { get; set; }

        public Kunde? KundeModel { get; set; }

        public List<Ordre> KundeOrdrer { get; set; } = new List<Ordre>();

        override protected async Task OnInitializedAsync()
        {
            var kundeResult = await KundeService.GetKunde(KundeId);

            if (kundeResult != null)
            {
                KundeModel = kundeResult;
            }
            else
            {
                KundeModel = new Kunde { KundeId = 0};
            }

            var ordreResult = await OrdreService.GetOrdrer(KundeId);

            if (ordreResult != null)
            {
                KundeOrdrer = ordreResult.OrderByDescending(o => o.OrdreId).ToList();
            }
        }
    }
}
