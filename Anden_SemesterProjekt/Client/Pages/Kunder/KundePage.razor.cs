using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Pages.Kunder
{
    public partial class KundePage
    {
        private List<Kunde>? kunder;

        [Inject]
        public IKundeClientService KundeService { get; set; }

        [Inject]
        private IJSRuntime JS { get; set; }

        private async Task UpdateKunder()
        {
            var result = await KundeService.GetKunder();

            if (result != null)
            {
                kunder = result.OrderByDescending(k => k.KundeId).ToList();
            }
            else if (result == null)
            {
                kunder = null;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await UpdateKunder();
        }

        private void OnSelectKunde(Kunde kunde)
        {
            NavigationManager.NavigateTo($"/kunder/{kunde.KundeId}");
        }

        private void OnEditKunde(Kunde kunde)
        {
            NavigationManager.NavigateTo($"/kunder/edit/{kunde.KundeId}");
        }

        private async Task OnDeleteKunde(Kunde kunde)
        {
            var confirmDelete = await JS.InvokeAsync<bool>("confirm", "Er du sikker på, at du vil slette denne kunde?");

            if (confirmDelete)
            {
                var result = await KundeService.DeleteKunde(kunde.KundeId);

                if (result.IsSuccessStatusCode)
                {
                    await UpdateKunder();
                }
                else
                {
                    await JS.InvokeVoidAsync("alert", "Der skete en fejl under sletning af kunden. Tjek evt. om kunden har ordrer som ikke er afsluttet.");
                }
            }
        }

        private void NavigateToCreateKunde()
        {
            NavigationManager.NavigateTo("/kunder/opret");
        }
    }
}
