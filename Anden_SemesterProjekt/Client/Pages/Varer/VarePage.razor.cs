using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Net.Http.Json;
using Anden_SemesterProjekt.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Anden_SemesterProjekt.Client.Components.Varer;


namespace Anden_SemesterProjekt.Client.Pages.Varer
{
    public partial class VarePage
    {
        public List<Vare> Varer { get; set; } = new List<Vare>();
        public List<Ydelse> Ydelser { get; set; } = new List<Ydelse>();

        //private VareListComponent vareListComponent;

        //En service, som skal injectes til at hente og manipulere data fra serveren via api kaldet. 
        [Inject]
        public IVareClientService VareService { get; set; }

       
        //Denne metoder opdaterer listen over Varer, når der er tilføjet en ny vare. Ved genkald af metoden "UpdateVare".
        private async Task OnVareAddedHandler()
        {
            Varer = await VareService.GetAktiveVarer();
            StateHasChanged();
        }
        private async Task OnYdelseAddedHandler()
        {
            Ydelser = await VareService.GetAktiveYdelser();
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            try
                
            {
                var result = await VareService.GetAktiveVarer();
                if (result != null)
                {
                    Varer = result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fejl ved hentning af Varer: {e.Message}");

            }
            try
            {
                var ydelsesResult = await VareService.GetAktiveYdelser();
                if (ydelsesResult != null)
                {
                    Ydelser = ydelsesResult;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fejl ved hentning af Ydelser: {e.Message}");
            }
        }


        

    }
}
