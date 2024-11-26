using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Pages.Varer
{
    public partial class VarePage
    {
        private List<Vare>? varer;

        //En service, som skal injectes til at hente og manipulere data fra serveren via api kaldet. 
        [Inject]
        public IVareClientService VareService { get; set; }

        //En service, som skal injectes for at kunne bruge JavaScript interop i Blazor, feks. alert , confirm. 
        [Inject]
        private IJSRuntime JS { get; set; }

        private async Task UpdateVare()
        {
            try
            {
                var result = await VareService.GetAktiveVarer();

                if (result != null)
                {
                    varer = result.OrderBy(v => v.Beskrivelse).ToList();
                }
                else
                {
                    varer = new List<Vare>();
                }
            }
            //Hvis der opstår en exception under hentning af varer, så vises en alert med fejlbeskeden.
            catch (Exception e)
            {
                await JS.InvokeVoidAsync("alert", "Der skete en fejl under hentning af varer." + e.Message);

            }
        }

        //UpdateYdelse

        //Denne metode kaldes, når komponenten er loaded. For at hente listen over varer fra serveren.
        protected override async Task OnInitializedAsync()
        {
            await UpdateVare();
        }

        //Denne metoder opdaterer listen over varer, når der er tilføjet en ny vare. Ved genkald af metoden "UpdateVare".
        private async Task OnVareAddedHandler()
        {
            await UpdateVare();
        }

        //Denne metode navigerer brugeren til en ny side, hvor der vises detaljer om en specifik vare, baseret på varens ID.
        private void OnSelectVare(Vare vare)
        {
            NavigationManager.NavigateTo($"/varer/{vare.Id}");
        }

        //Denne metode navigerer brugeren til en redigere side, hvor brugeren kan redigere en specifik vare, baseret på varens ID.
        private void OnEditKunde(Vare vare)
        {
            NavigationManager.NavigateTo($"/varer/edit/{vare.Id}");
        }

        //Viser først en JS confirm dialog, som spørger brugeren om de er sikker på at de vil slette varen.
        //Derefter kalder metoden DeleteVare fra VareService, som sletter varen fra databasen.
        //Hvis sletningen lykkedes, så opdateres listen over varer.
        //Hvis sletningen fejler, så vises en alert med fejlbeskeden.
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
