using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Components

{
    public partial class OpretOrdreComponent
    {
        [Inject] private IJSRuntime JS { get; set; } // JavaScript runtime
        public Ordre nyOrdre = new Ordre();
        [Parameter] public Kunde ordreKunde { get; set; }
        public Mekaniker? ordreMekaniker = new Mekaniker();
        public Udlejning? ordreUdlejning = new Udlejning();
        public List<Vare> alleVarer = new List<Vare>();
        public KundeScooter ordreKundeScooter = new KundeScooter();
        public VareLinje ordreVareLinje = new VareLinje();
        public List<VareLinje> ordreVareLinjer = new List<VareLinje>();
        private string søgeTekst = string.Empty;
        private List<Vare> vareForslag = new List<Vare>();
        private bool visForslag = false;
        private double? totalPris = 0;
        private int inputAntal;

        private bool addModal = false;

        [Inject] public IVareClientService VareService { get; set; }
        [Inject] public IOrdreClientService OrdreService { get; set; }
        [Inject] public IScooterClientService ScooterService { get; set; }
        //[Parameter] public EventCallback OnScooterAdded { get; set; }
        protected override async Task OnInitializedAsync()
        {
            alleVarer = await VareService.GetAktiveVarer();
        }

        private void OnSearchTextChanged(ChangeEventArgs e)
        {
            søgeTekst = e.Value.ToString();
            if (!string.IsNullOrWhiteSpace(søgeTekst))
            {
                vareForslag = alleVarer
                    .Where(p => p.Beskrivelse.Contains(søgeTekst, StringComparison.OrdinalIgnoreCase))
                    .Take(10) 
                    .ToList();
                visForslag = vareForslag.Count > 0;
            }
            else
            {
                visForslag = false;
            }
        }
        private void vælgVare(Vare vare)
        {
            søgeTekst = $"{vare.Beskrivelse}, {vare.Pris:0.00} kr.";
            ordreVareLinje.Vare = vare;
            visForslag = false;
        }

        private void InputChanged(ChangeEventArgs e)
        {
            ordreVareLinje.Antal = int.TryParse(e.Value.ToString(), out int result) ? result : 0;
            BeregnTotalPris();
        }

        private void BeregnTotalPris()
        {
            totalPris = ordreVareLinje.Antal * ordreVareLinje.Vare.Pris;
           
        }



        private async Task HandleValidSubmit()
        {
            try
            {
                if (ordreKunde == null)
                {
                    throw new InvalidOperationException("Ingen kunde valgt.Vælg venligst en kunde");
                }

                var response = await OrdreService.AddOrdre(nyOrdre);

                if (response != null)
                {
                    StateHasChanged();
                    nyOrdre = new Ordre();
                  
                    addModal = false;
                    await JS.InvokeVoidAsync("alert", "Ordre blev oprettet.");
                }
                else
                {
                    throw new InvalidOperationException("API oprettelsen mislykkedes.");
                }

            }
            catch (Exception ex)
            {
                var errorBox = await JS.InvokeAsync<string>("alert", ex.Message);
            }
        }
        private async Task ShowAddModal()
        {
            addModal = true;
            StateHasChanged();
        }
        private void CloseAddModal()
        {
            addModal = false;
        }

    }
}

