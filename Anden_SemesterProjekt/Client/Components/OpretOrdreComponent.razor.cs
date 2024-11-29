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
        public Vare ordreVare = new Vare();
        public List<VareLinje> ordreVareLinjer = new List<VareLinje>();
        private string søgeTekst = string.Empty;
        private List<Vare> vareForslag = new List<Vare>();
        private bool visForslag = false;
        private double? ordreTotalPris = 0;
        private bool checkboxValue { get; set; } = false;


        private bool addModal = false;

        [Inject] public IVareClientService VareService { get; set; }
        [Inject] public IOrdreClientService OrdreService { get; set; }
        [Inject] public IScooterClientService ScooterService { get; set; }
        //[Parameter] public EventCallback OnScooterAdded { get; set; }
        protected override async Task OnInitializedAsync()
        {
            alleVarer = await VareService.GetAktiveVarer();
            ordreVareLinje = new VareLinje();
            ordreVareLinje.Vare = ordreVare;
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
        private void VælgVare(Vare vare)
        {
            søgeTekst = $"{vare.Beskrivelse}";
         ordreVare = vare;
            visForslag = false;
            ordreVareLinje.Vare = ordreVare;
            ordreVareLinje.VarePris = vare.Pris;
            StateHasChanged();
        }

        private void FjernVare(VareLinje vare)
        {
            ordreVareLinjer.Remove(vare);
            ordreTotalPris = ordreVareLinjer.Sum(p => p.VarePris);
            StateHasChanged();

            if (vare.Antal == 0)
            {
                ordreVareLinjer.Remove(vare);
                StateHasChanged();
            }
        }

        private void FjernVareVedNul()
        {
            ordreVareLinjer.RemoveAll(p => p.Antal <= 1);
            ordreTotalPris = ordreVareLinjer.Sum(p => p.VarePris);
            StateHasChanged();
        }
        private void TilføjVare()
        {
            if(!ordreVareLinjer.Any(o => o.Vare.Id == ordreVareLinje.Vare.Id))
            {
                ordreVareLinjer.Add(ordreVareLinje);
                ordreVareLinje = new VareLinje();
                ordreVare = new Vare();
                ordreVareLinje.Vare = ordreVare;
                ordreVareLinje.VarePris = ordreVare.Pris;
                ordreVare = new Vare();
                ordreTotalPris = ordreVareLinjer.Sum(p => p.VarePris);
                søgeTekst = string.Empty;
                StateHasChanged();
            }
            else
            {
                var o = ordreVareLinjer.Find(p => p.Vare.Id == ordreVareLinje.Vare.Id);
                o.Antal += ordreVareLinje.Antal;
                ordreTotalPris = ordreVareLinjer.Sum(p => p.VarePris);
                ordreVareLinje = new VareLinje();
                ordreVare = new Vare();
                ordreVareLinje.Vare = ordreVare;
                ordreVareLinje.VarePris = ordreVare.Pris;
                ordreVare = new Vare();
                søgeTekst = string.Empty;
                StateHasChanged();
            }
        }

        //private void InputChanged(ChangeEventArgs e)
        //{
        //    ordreVareLinje.Antal = int.TryParse(e.Value.ToString(), out int result) ? result : 0;
        //    BeregnTotalPris();
        //}

        //private void BeregnTotalPris()
        //{
        //    totalPris = ordreVareLinje.Antal * ordreVareLinje.Vare.Pris;

        //}



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

