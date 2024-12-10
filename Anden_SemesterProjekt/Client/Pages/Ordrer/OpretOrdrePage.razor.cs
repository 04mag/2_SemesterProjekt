using Anden_SemesterProjekt.Client.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text;


namespace Anden_SemesterProjekt.Client.Pages.Ordrer;

public partial class OpretOrdrePage
{
    #region Data og Initialisering

    public Ordre nyOrdre = new();
    private double nyOrdreTotalPris;
    private Mekaniker ordreMekaniker;
    private List<Mekaniker> alleMekanikere = new();
    private VareLinje ordreVareLinje = new();
    private List<VareLinje> ordreVareLinjer = new();

    private Udlejning? udlejning;
    private Vare ordreVare = new();
    private List<KundeScooter> kundeScootere = new();
    private List<UdlejningsScooter> udlejningsScootere = new();
    private KundeScooter? ordreKundeScooter;
    private UdlejningsScooter udlejningsScooter;
    private int udlejningsScooterId;
    private bool checkboxValue;
    private bool kundeValgt;
    private bool opretKundeModal;
    private bool isChecked = false;
    private bool udlejningAktiveret;

    private bool isBusy = false;

    // Søgning på varer og kunder

    #region Søgning på varer og kunder

    private string søgeTekstVarer = string.Empty;
    private List<Vare> alleVarer = new();
    private List<Vare> vareForslag = new();
    private List<Ydelse> alleYdelser = new();
    private List<Ydelse> ydelserForslag = new();
    private bool visVareForslag;

    private string søgeTekstKunder = string.Empty;
    private List<Kunde> alleKunder = new();
    private List<Kunde> kundeForslag = new();
    private bool visKundeForslag;

    #endregion

    // Søgning på varer og kunder

    [Parameter] public Kunde ordreKunde { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
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
        alleYdelser = await VareService.GetAktiveYdelser();
        alleKunder = await KundeService.GetKunder();
        ordreVareLinje = new VareLinje();
        udlejningsScootere = await ScooterService.GetAllUdlejningsScootereAsync();
        udlejningsScootere = udlejningsScootere.Where(s => s.ErTilgængelig).ToList();
        ordreVareLinje.Vare = ordreVare;
        alleMekanikere = await MekanikerService.GetMekanikere();
        if (ordreKunde != null) ordreMekaniker = ordreKunde.TilknyttetMekaniker;
    }

    private void VareSøgefeltÆndret(ChangeEventArgs e)
    {
        søgeTekstVarer = e.Value.ToString();
        if (!string.IsNullOrWhiteSpace(søgeTekstVarer))
        {
            vareForslag = alleVarer
                .Where(p => p.Beskrivelse.Contains(søgeTekstVarer, StringComparison.OrdinalIgnoreCase))
                .Take(5)
                .ToList();

            ydelserForslag = alleYdelser
                .Where(p => p.Beskrivelse.Contains(søgeTekstVarer, StringComparison.OrdinalIgnoreCase))
                .Take(5)
                .ToList();
            visVareForslag = vareForslag.Count > 0 || ydelserForslag.Count > 0;
        }
        else
        {
            visVareForslag = false;
        }
    }

    private void KundeSøgefeltÆndret(ChangeEventArgs e)
    {
        søgeTekstKunder = e.Value.ToString();
        if (!string.IsNullOrWhiteSpace(søgeTekstKunder))
        {
            kundeForslag = alleKunder
                .Where(k => k.Navn.Contains(søgeTekstKunder, StringComparison.OrdinalIgnoreCase) ||
                            k.Email.Contains(søgeTekstKunder, StringComparison.OrdinalIgnoreCase) ||
                            k.TlfNumre.Any(t =>
                                t.TelefonNummer.Contains(søgeTekstKunder, StringComparison.OrdinalIgnoreCase)))
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

        nyOrdre.MekanikerId = kunde.MekanikerId;

        ordreMekaniker = kunde.TilknyttetMekaniker;
        MekanikerÆndres();

        visKundeForslag = false;
        kundeScootere = kunde.Scootere;
        StateHasChanged();
        kundeValgt = true;
    }

    private void FjernVare(VareLinje vare)
    {
        nyOrdre.VareLinjer.Remove(vare);
    }

    private void OpretKunde()
    {
        opretKundeModal = true;
    }

    private void LukOpretKundeModal()
    {
        opretKundeModal = false;
    }

    private void MekanikerÆndres()
    {
        ordreMekaniker = alleMekanikere.FirstOrDefault(m => m.MekanikerId == nyOrdre.MekanikerId);
    }

    private void VælgVare(Vare vare)
    {
        if (vare is Ydelse ydelse)
            ordreVareLinje = new VareLinje
            {
                VareId = ydelse.Id,
                VarePris = ydelse.Pris,
                Antal = 1, // Standard antal
                VareBeskrivelse = ydelse.Beskrivelse,
                YdelseAntalTimer = ydelse.AntalTimer
            };
        else
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
        var eksisterendeVareLinje = nyOrdre.VareLinjer.FirstOrDefault(v
            => v.VareId == ordreVareLinje.VareId
               && v.VarePris == ordreVareLinje.VarePris
               && v.Rabat == ordreVareLinje.Rabat);
        if (eksisterendeVareLinje != null)
            eksisterendeVareLinje.Antal += ordreVareLinje.Antal;
        else
            nyOrdre.VareLinjer.Add(new VareLinje
            {
                VareId = ordreVareLinje.VareId,
                VarePris = ordreVareLinje.VarePris,
                Rabat = ordreVareLinje.Rabat,
                Antal = ordreVareLinje.Antal,
                VareBeskrivelse = ordreVareLinje.VareBeskrivelse,
                YdelseAntalTimer = ordreVareLinje.YdelseAntalTimer
            });

        NulstilVareInput();
    }

    private async Task SetUdlejningsScooter()
    {
        if (udlejningsScooterId == 0) return;
        udlejning = new Udlejning();
        udlejningsScooter = udlejningsScootere.FirstOrDefault(s => s.ScooterId == udlejningsScooterId);
        udlejning.UdlejningsScooterId = udlejningsScooterId;
        udlejning.SlutDato = nyOrdre.SlutDato;
        udlejning.SelvrisikoUdløst = false;
        udlejning.AntalKmKørt = 0;
        udlejning.OrdreId = 0;
        nyOrdre.Udlejning = udlejning;
    }

    public async Task OpretOrdre()
    {
        

        // Tjekker at alle ordreinfo er tilstede inden vi opretter.
        if (nyOrdre.KundeId == 0)
        {
            await JS.InvokeVoidAsync("alert", "Vælg en kunde");
            return;
        }

        if (nyOrdre.VareLinjer.Count == 0)
        {
            await JS.InvokeVoidAsync("alert", "Tilføj mindst én vare");
            return;
        }

        if (nyOrdre.SlutDato.Date < nyOrdre.StartDato.Date)
        {
            await JS.InvokeVoidAsync("alert", "Slutdato kan ikke være før startdato");
            return;
        }

        if (nyOrdre.VareLinjer.Any(v => v.YdelseAntalTimer > 0 && nyOrdre.MekanikerId == null))
        {
            await JS.InvokeVoidAsync("alert", "Vælg en mekaniker");
            return;
        }

        if (nyOrdre.VareLinjer.Any(v => v.YdelseAntalTimer > 0 && nyOrdre.KundeScooterId == null))
        {
            await JS.InvokeVoidAsync("alert", "Vælg en scooter");
            return;
        }

        if (udlejningsScooterId == 0 && udlejningAktiveret)
        {
            await JS.InvokeVoidAsync("alert", "Vælg en scooter til udlejning");
            return;
        }

        //Sætter isBusy til true, så brugeren ikke kan trykke flere gange på knappen
        isBusy = true;

        StateHasChanged();

        if (nyOrdre.OrdreContainsYdelse())
        {
            nyOrdre.ErAfsluttet = false;
            await SetUdlejningsScooter();
        }
        else
        {
            nyOrdre.ErAfsluttet = true;
            nyOrdre.MekanikerId = null;
            nyOrdre.KundeScooterId = null;
            nyOrdre.SlutDato = DateTime.Now.Date;
            nyOrdre.BetalingsDato = DateTime.Now.Date;
        }

        nyOrdre.StartDato = DateTime.Now.Date;

        var result = await OrdreService.AddOrdre(nyOrdre);
        if (result.IsSuccessStatusCode)
        {
            if (nyOrdre.Udlejning != null)
            {
                //Bør måske flyttes til repository istedet???
                await SetUdlejningsScooterTilIkkeTilgængelig();
            }
            // Når ordren er oprettet, navigér til den nye ordre med det genererede ordreId
            NavigationManager.NavigateTo($"/ordrer");  // Antag, at OrdreId er et property på ordren
            await JS.InvokeVoidAsync("alert", "Ordre oprettet");
        }
        else
        {
            await JS.InvokeVoidAsync("alert", "Ordre kunne ikke oprettes");
        }

        isBusy = false;
    }
    private async Task NyKunde(Kunde? nyKunde)
    {
        LukOpretKundeModal();
        nyOrdre.Kunde = nyKunde;
        søgeTekstKunder = nyKunde.Navn;
        nyOrdre.MekanikerId = nyKunde.MekanikerId;

        ordreMekaniker = nyKunde.TilknyttetMekaniker;
        MekanikerÆndres();

        opretKundeModal = false; // Luk modalvinduet
        alleKunder = await KundeService.GetKunder(); // Opdater kundeliste
        StateHasChanged(); // Opdater UI
    }
    private void NulstilVareInput()
    {
        ordreVareLinje = new VareLinje();
        ordreVare = new Vare();
        ordreVareLinje.Vare = ordreVare;
        ordreVareLinje.VarePris = ordreVare.Pris;
        søgeTekstVarer = string.Empty;
    }


    private void NulstilAlleFelter()
    {
        ordreMekaniker = null;
        nyOrdre = new Ordre();
        ordreKunde = new Kunde();
        ordreVareLinjer = new List<VareLinje>();
        kundeValgt = false;
        søgeTekstKunder = "";
        NulstilVareInput();
    }
    private async Task SetUdlejningsScooterTilIkkeTilgængelig()
    {
        if (udlejningsScooterId != 0) await ScooterService.UpdateScooterTilgængelighed(udlejningsScooterId, false);

    }
    private void MekanikerValgt()
    {

        StateHasChanged();
    }


    private void KundeScooterÆndres()
    {
        ordreKundeScooter = kundeScootere.FirstOrDefault(s => s.ScooterId == nyOrdre.KundeScooterId);
    }
}