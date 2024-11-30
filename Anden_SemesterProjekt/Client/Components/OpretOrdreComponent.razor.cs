using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Anden_SemesterProjekt.Client.Components

{
    public partial class OpretOrdreComponent
    {
        #region Data og Initialisering
        public Ordre nyOrdre = new Ordre();
        private Mekaniker? ordreMekaniker = new Mekaniker();
        private List<Mekaniker> alleMekanikere = new List<Mekaniker>();
        private VareLinje ordreVareLinje = new VareLinje();
        private Vare ordreVare = new Vare();
        private List<VareLinje> ordreVareLinjer = new List<VareLinje>();
        private List<KundeScooter> kundeScootere = new List<KundeScooter>();
        private bool checkboxValue = false;
        private bool kundeValgt = false;
        private double? ordreTotalPris = 0;
        private bool opretKundeModal = false;
        private string kundeNavn = string.Empty;
        private string kundeEmail = string.Empty;
        private string mekanikerNavn = string.Empty;
        private string kundeScooter = string.Empty;

        // Søgning på varer og kunder
        #region Søgning på varer og kunder
        private string søgeTekstVarer = string.Empty;
        private List<Vare> alleVarer = new List<Vare>();
        private List<Vare> vareForslag = new List<Vare>();
        private bool visVareForslag = false;

        private string søgeTekstKunder = string.Empty;
        private List<Kunde> alleKunder = new List<Kunde>();
        private List<Kunde> kundeForslag = new List<Kunde>();
        private bool visKundeForslag = false;
        #endregion
        // Søgning på varer og kunder

        [Parameter] public Kunde ordreKunde { get; set; }
        [Inject] public IAnsatClientService MekanikerService { get; set; }
        [Inject] public IVareClientService VareService { get; set; }
        [Inject] public IOrdreClientService OrdreService { get; set; }
        [Inject] public IKundeClientService KundeService { get; set; }
        [Inject] public IScooterClientService ScooterService { get; set; }
        [Inject] private IJSRuntime JS { get; set; } // JavaScript runtime
        #endregion // Data og Initialisering
        protected override async Task OnInitializedAsync()
        {
            alleVarer = await VareService.GetAktiveVarer();
            alleKunder = await KundeService.GetKunder();
            ordreVareLinje = new VareLinje();
            ordreVareLinje.Vare = ordreVare;
            alleMekanikere = await MekanikerService.GetMekanikere();
            if (ordreKunde != null)
            { 
                ordreMekaniker = ordreKunde.TilknyttetMekaniker;
            }
        }
        #region VareSøgning
        private void VareSøgefeltÆndret(ChangeEventArgs e)
        {
            søgeTekstVarer = e.Value.ToString();
            if (!string.IsNullOrWhiteSpace(søgeTekstVarer))
            {
                vareForslag = alleVarer
                    .Where(p => p.Beskrivelse.Contains(søgeTekstVarer, StringComparison.OrdinalIgnoreCase))
                    .Take(5) 
                    .ToList();
                visVareForslag = vareForslag.Count > 0;
            }
            else
            {
                visVareForslag = false;
            }

           

        }
        private void VælgVare(Vare vare)
        {
            søgeTekstVarer = $"{vare.Beskrivelse}";
            visVareForslag = false;
            ordreVareLinje.Vare = vare;
            ordreVareLinje.VarePris = vare.Pris;

            StateHasChanged();
        }

        #endregion // VareSøgning
        #region KundeSøgning
        private void KundeSøgefeltÆndret(ChangeEventArgs e)
        {
            søgeTekstKunder = e.Value.ToString();
            if (!string.IsNullOrWhiteSpace(søgeTekstKunder))
            {
                kundeForslag = alleKunder
                    .Where(k => k.Navn.Contains(søgeTekstKunder, StringComparison.OrdinalIgnoreCase) || k.Email.Contains(søgeTekstKunder, StringComparison.OrdinalIgnoreCase))
                    .Take(5)
                    .ToList();
                visKundeForslag = kundeForslag.Count > 0;
            }
            else
            {
                visKundeForslag = false;
            }
        }
        private void VælgKunde(Kunde kunde)
        {
            søgeTekstKunder = $"{kunde.Navn}";
            nyOrdre.Kunde = kunde;
            nyOrdre.KundeId = kunde.KundeId;
            nyOrdre.MekanikerId = kunde.MekanikerId;
            kundeNavn = kunde.Navn;
            kundeEmail = kunde.Email;
            mekanikerNavn = kunde.TilknyttetMekaniker.Navn;
           
            visKundeForslag = false;
            kundeScootere = kunde.Scootere;
            StateHasChanged();
            kundeValgt = true;
        }
        #endregion // KundeSøgning
        #region Vare håndtering
        private void FjernVare(VareLinje vare)
        {
            ordreVareLinjer.Remove(vare);
            ordreTotalPris = ordreVareLinjer.Sum(p => p.VarePris);
            StateHasChanged();

                ordreVareLinjer.Remove(vare);
                StateHasChanged();
        }

        private void BindScooter(ChangeEventArgs e)
        {
            kundeScooter = e.Value.ToString(); // Opdater hovedinput
          StateHasChanged();
        }

        private void OpretKunde()
        {
            opretKundeModal = true;
        }
        private void LukOpretKundeModal()
        {
            opretKundeModal = false;
        }

        private void FjernVareVedNul()
        {
            ordreVareLinjer.RemoveAll(p => p.Antal <= 1);
            ordreTotalPris = ordreVareLinjer.Sum(p => p.VarePris);
            StateHasChanged();
        }
        private void TilføjVare()
        {
            if(!ordreVareLinjer.Any(o => o.Vare.Id == ordreVareLinje.Vare.Id && o.Vare.Pris == ordreVareLinje.VarePris))
            {
                ordreVareLinjer.Add(ordreVareLinje);
                ordreVareLinje = new VareLinje();
                ordreVare = new Vare();
                ordreVareLinje.Vare = ordreVare;
                ordreVareLinje.VarePris = ordreVare.Pris;
                ordreVare = new Vare();
                ordreTotalPris = ordreVareLinjer.Sum(p => p.VarePris);
                søgeTekstVarer = string.Empty;
                StateHasChanged();
            }
            else
            {
                var o = ordreVareLinjer.Find(p => p.Vare.Id == ordreVareLinje.Vare.Id);
                o.Antal += ordreVareLinje.Antal;
                ordreTotalPris = ordreVareLinjer.Sum(p => p.VarePris * p.Antal);
                NulstilVareInput();
                StateHasChanged();
            }
        }
        #endregion // vare håndtering
        public void OpretOrdre()
        {
            nyOrdre.VareLinjer = ordreVareLinjer;
            nyOrdre.Mekaniker = ordreMekaniker;
            nyOrdre.Kunde = ordreKunde;
            nyOrdre.BetalingsDato = null;
            nyOrdre.ErBetalt = checkboxValue;
            nyOrdre.ErAfsluttet = false;
            nyOrdre.StartDato = DateTime.Now;

            
            OrdreService.AddOrdre(nyOrdre);

        }
        private async Task NyKunde(Kunde? nyKunde)
        {
           LukOpretKundeModal();
           nyOrdre.Kunde = nyKunde;
            søgeTekstKunder = nyKunde.Navn;
            nyOrdre.MekanikerId = nyKunde.MekanikerId;
            opretKundeModal = false; // Luk modalvinduet
            alleKunder = await KundeService.GetKunder(); // Opdater kundeliste
            StateHasChanged(); // Opdater UI
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
        private void NulstilVareInput()
        {
            ordreVareLinje = new VareLinje();
            ordreVare = new Vare();
            ordreVareLinje.Vare = ordreVare;
            ordreVareLinje.VarePris = ordreVare.Pris;
            søgeTekstVarer = string.Empty;
        }
    }
}

