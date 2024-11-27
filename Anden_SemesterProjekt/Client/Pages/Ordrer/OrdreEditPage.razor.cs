using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Anden_SemesterProjekt.Client.Pages.Ordrer
{
    public partial class OrdreEditPage
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IOrdreClientService OrdreService { get; set; }

        public Ordre? OrdreModel { get; set; } = new Ordre();

        public EditContext EditContext { get; set; }

        protected override void OnInitialized()
        {
            EditContext = new EditContext(OrdreModel);
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Ordre indhentes!");
            var ordreResult = await OrdreService.GetOrdre(Id);
            
            if (ordreResult == null)
            {
                Console.WriteLine("Ordre er lig null!");
            }

            if (ordreResult != null)
            {
                Console.WriteLine("Ordre er ikke null!");
                OrdreModel = ordreResult;
            }
        }
    }
}
