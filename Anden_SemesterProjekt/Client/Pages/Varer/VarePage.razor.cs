﻿using Anden_SemesterProjekt.Client.Services;
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
        private List<Vare> varer = new List<Vare>();
        
        private VareListComponent vareListComponent;

        //En service, som skal injectes til at hente og manipulere data fra serveren via api kaldet. 
        [Inject]
        public IVareClientService VareService { get; set; }

       
        //Denne metoder opdaterer listen over varer, når der er tilføjet en ny vare. Ved genkald af metoden "UpdateVare".
        private async Task OnVareAddedHandler()
        {
            varer = await VareService.GetAktiveVarer();
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                // Hent varer fra tjenesten
                varer = await VareService.GetAktiveVarer();
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl ved hentning af varer: {ex.Message}");
                varer = new List<Vare>();
                
            }
        }


        

    }
}