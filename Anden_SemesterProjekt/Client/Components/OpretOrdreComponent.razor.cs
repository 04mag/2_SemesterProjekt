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
        private double nyOrdreTotalPris = 0;
        private Mekaniker ordreMekaniker;
        private List<Mekaniker> alleMekanikere = new List<Mekaniker>();
        private VareLinje ordreVareLinje = new VareLinje();
        private List<VareLinje> ordreVareLinjer = new List<VareLinje>();

        private Udlejning? udlejning;
        private Vare ordreVare = new Vare();
        private List<KundeScooter> kundeScootere = new List<KundeScooter>();
        private List<UdlejningsScooter> udlejningsScootere = new List<UdlejningsScooter>();
        private KundeScooter? ordreKundeScooter;
        private UdlejningsScooter udlejningsScooter;
        private int udlejningsScooterId;
        private bool checkboxValue = false;
        private bool kundeValgt = false;
        private bool opretKundeModal = false;

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
            udlejningsScootere = await ScooterService.GetAllUdlejningsScootereAsync();
            udlejningsScootere = udlejningsScootere.Where(s => s.ErTilgængelig == true).ToList();
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

        #endregion // VareSøgning



        #region KundeSøgning

        private void KundeSøgefeltÆndret(ChangeEventArgs e)
        {
            søgeTekstKunder = e.Value.ToString();
            if (!string.IsNullOrWhiteSpace(søgeTekstKunder))
            {
                kundeForslag = alleKunder
                    .Where(k => k.Navn.Contains(søgeTekstKunder, StringComparison.OrdinalIgnoreCase) ||
                                k.Email.Contains(søgeTekstKunder, StringComparison.OrdinalIgnoreCase) ||
                                k.TlfNumre.Any(t => t.TelefonNummer.Contains(søgeTekstKunder, StringComparison.OrdinalIgnoreCase)))
                    .Take(5)
                    .ToList();
                visKundeForslag = kundeForslag.Count > 0;
            }
            else
            {
                visKundeForslag = false;
            }
        }

        private void KundeVælges(Kunde kunde)
        {
            søgeTekstKunder = $"{kunde.Navn}";
            ordreKunde = kunde;
            nyOrdre.KundeId = kunde.KundeId;

            if (ordreVareLinjer.Any(v => v.Vare is Ydelse))
            {
                nyOrdre.MekanikerId = kunde.MekanikerId;
            }

            ordreMekaniker = kunde.TilknyttetMekaniker;
            MekanikerÆndres();

            visKundeForslag = false;
            kundeScootere = kunde.Scootere;
            StateHasChanged();
            kundeValgt = true;
        }

        #endregion // KundeSøgning

        #region Vare håndtering

        private void FjernVare(VareLinje vare)
        {
            nyOrdre.VareLinjer.Remove(vare);
            nyOrdreTotalPris = nyOrdre.VareLinjer.Sum(v => v.GetTotalPris());
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
            nyOrdre.VareLinjer.RemoveAll(p => p.Antal < 1);
            StateHasChanged();
        }

        private void MekanikerÆndres()
        {
            ordreMekaniker = alleMekanikere.FirstOrDefault(m => m.MekanikerId == nyOrdre.MekanikerId);
        }

        private void KundeScooterÆndres()
        {
            ordreKundeScooter = kundeScootere.FirstOrDefault(s => s.ScooterId == nyOrdre.KundeScooterId);
        }

        private void VælgVare(Vare vare)
        {
            ordreVareLinje = new VareLinje
            {
               
                VareId = vare.Id,
                VarePris = vare.Pris,
                Antal = 1, // Standard antal
                VareBeskrivelse = vare.Beskrivelse
            };
            søgeTekstVarer = vare.Beskrivelse;
            visVareForslag = false;
            StateHasChanged();
        }
        private void TilføjVare()
        {
            var eksisterendeVareLinje = ordreVareLinjer.FirstOrDefault(v
                => v.VareId == ordreVareLinje.VareId 
                   && v.VarePris == ordreVareLinje.VarePris
                   && v.Rabat == ordreVareLinje.Rabat);
            if (eksisterendeVareLinje != null)
            {
                eksisterendeVareLinje.Antal += ordreVareLinje.Antal;
            }
            else
            {
                nyOrdre.VareLinjer.Add(new VareLinje
                {
                    VareId = ordreVareLinje.VareId,
                    VarePris = ordreVareLinje.VarePris,
                    Rabat = ordreVareLinje.Rabat,
                    Antal = ordreVareLinje.Antal,
                    VareBeskrivelse = ordreVareLinje.VareBeskrivelse,
                });
            }
                 
            NulstilVareInput();
        }

        private async Task SetUdlejningsScooter()
        {
            udlejning = new Udlejning();
            udlejningsScooter = udlejningsScootere.FirstOrDefault(s => s.ScooterId == udlejningsScooterId);
            udlejning.UdlejningsScooterId = udlejningsScooterId;
            udlejning.SlutDato = nyOrdre.SlutDato;
            udlejning.SelvrisikoUdløst = false;
            udlejning.AntalKmKørt = 0;
            nyOrdre.Udlejning = udlejning;
            if (udlejningsScooterId != 0)
            {
                await ScooterService.UpdateScooterTilgængelighed(udlejningsScooterId, false);
            }
        }

        #endregion // vare håndtering
        public async Task OpretOrdre()
        {
            nyOrdre.Mekaniker = ordreMekaniker;
            nyOrdre.KundeScooter = ordreKundeScooter;
         
            nyOrdre.ErBetalt = false;
            nyOrdre.ErAfsluttet = false;
            nyOrdre.StartDato = DateTime.Now;
            nyOrdre.BetalingsDato = DateTime.Now;
            SetUdlejningsScooter();

            var result = await OrdreService.AddOrdre(nyOrdre);
            if (result != null)
            {
                nyOrdre = new Ordre();
                //nyOrdreTotalPris = 0;
                ordreVareLinjer = new List<VareLinje>();
                ordreVareLinje = new VareLinje();
                ordreVare = new Vare();
                ordreVareLinje.Vare = ordreVare;
                //ordreMekaniker = new Mekaniker();
                //ordreKundeScooter = new KundeScooter();
                //ordreKunde = new Kunde();
                kundeValgt = false;
                søgeTekstKunder = "";
                StateHasChanged();
                
                await JS.InvokeVoidAsync("alert", "Ordre oprettet");
            }
            else
            {
                await JS.InvokeVoidAsync("alert", "Ordre kunne ikke oprettes");
            }
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


        private void UdlejnigsScooterVælges(UdlejningsScooter udlejningsScooter)
        {

            udlejningsScooter.ErTilgængelig = false;
            ScooterService.UpdateScooter(udlejningsScooter);
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

