using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Pages.Vare
{
    public partial class VarePage
    {
        private List<Vare>? varer;

        [Inject]
        public IVareClientService VareService { get; set; }

        [Inject]
        private IJSRuntime JS { get; set; }

        private async Task UpdateVare()
        {
            try
            {
                var result = await VareService.GetAktiveVarerOgYdelser();

                if (result != null)
                {
                    varer = result.OrderBy(v => v.Beskrivelse).ToList();
                }
                else
                {
                    varer = new List<Vare>();
                }
            }
            catch (Exception e)
            {
                await JS.InvokeVoidAsync("alert", "Der skete en fejl under hentning af varer." + e.Message);

            }
        }
        protected override async Task OnInitializedAsync()
        {
            await UpdateVare();
        }

        private async Task OnVareAddedHandler()
        {
            await UpdateVare();
        }

        private void OnSelectVare(Vare vare)
        {
            NavigationManager.NavigateTo($"/vare/{vare.Id}");
        }

        private void OnEditKunde(Vare vare)
        {
            NavigationManager.NavigateTo($"/vare/edit/{vare.Id}");
        }

        private async Task OnDeleteVare(Vare vare) 
        {
            var confirmDelete = await JS.InvokeAsync<bool>("confirm", "Er du sikker på at du vil slette denne vare?");

            if (confirmDelete)
            {
                var result = await VareService.DeleteVare(vare.Id);

                if (result.IsSuccessStatusCode)
                {
                    await UpdateVare();
                }
                else
                {
                    await JS.InvokeVoidAsync("alert", "Der skete en fejl under sletning af varen.");
                }
            }
        }
    }
}
