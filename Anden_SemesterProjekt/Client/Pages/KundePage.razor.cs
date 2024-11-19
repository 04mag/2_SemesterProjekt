
using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Pages
{
    public partial class KundePage
    {
        private List<Kunde>? kunder;

        [Inject]
        public IKundeClientService KundeService { get; set; }

        [Inject] 
        private IJSRuntime JS { get; set; }

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
            var confirmDelete = await JS.InvokeAsync<bool>("confirm", "Er du sikker på, at du vil slette denne kunde?");

            if (confirmDelete)
            {
                var result = await KundeService.DeleteKunde(kunde.KundeId);

                if (result.IsSuccessStatusCode)
                {
                    kunder = await KundeService.GetKunder();
                }
                else
                {
                    await JS.InvokeVoidAsync("alert", "Der skete en fejl under sletning af kunden.");
                }
            }
        }
    }
}
