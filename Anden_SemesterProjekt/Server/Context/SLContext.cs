using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Context
{
    public class SLContext: DbContext
    {
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<TlfNummer> TlfNumre { get; set; }
        public DbSet<Adresse> Adresser { get; set; }
        public DbSet<By> By { get; set; }
        public DbSet<Mekaniker> Mekanikere { get; set; }
        public DbSet<Scooter> Scootere { get; set; }
        public DbSet<Mærke> Mærker { get; set; }
        public DbSet<VareLinje> VareLinjer { get; set; }
        public DbSet<Udlejning> Udlejninger { get; set; }
        public DbSet<Vare> Varer { get; set; }
        public DbSet<Ordre> Ordrer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LocalHost;Database=SlDatabase;Trusted_Connection=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Oprette separate tabeller for hver Type.
            modelBuilder.Entity<KundeScooter>().ToTable("KundeScootere");
            modelBuilder.Entity<UdlejningsScooter>().ToTable("UdlejningsScootere");
            modelBuilder.Entity<Vare>().ToTable("Varer");
            modelBuilder.Entity<Ydelse>().ToTable("Ydelser");


            modelBuilder.Entity<Ordre>()
                .HasOne(o => o.Udlejning)
                .WithOne(u => u.Ordre)
                .HasForeignKey<Udlejning>(u => u.OrdreId);


            modelBuilder.Entity<Mærke>().HasData(
                new Mærke { MærkeId = 1, ScooterMærke = "Aprilla" },
                new Mærke { MærkeId = 2, ScooterMærke = "Derbi" },
                new Mærke { MærkeId = 3, ScooterMærke = "Karma" },
                new Mærke { MærkeId = 4, ScooterMærke = "Lindebjerg" },
                new Mærke { MærkeId = 5, ScooterMærke = "Pegasus" },
                new Mærke { MærkeId = 6, ScooterMærke = "Peugeot" },
                new Mærke { MærkeId = 7, ScooterMærke = "PGO" },
                new Mærke { MærkeId = 8, ScooterMærke = "Puch" },
                new Mærke { MærkeId = 9, ScooterMærke = "Vespa" },
                new Mærke { MærkeId = 10, ScooterMærke = "Yamaha" }
            );


            modelBuilder.Entity<Mekaniker>().HasData(
                new Mekaniker
                {
                    MekanikerId = 1,
                    Navn = "Troels Nielsen",
                    ErAktiv = true
                },
                new Mekaniker
                {
                    MekanikerId = 2,
                    Navn = "Mads Jensen",
                    ErAktiv = true
                },
                new Mekaniker
                {
                    MekanikerId = 3,
                    Navn = "Mikkel Larsen",
                    ErAktiv = true
                },
                new Mekaniker
                {
                    MekanikerId = 4,
                    Navn = "Anders Pedersen",
                    ErAktiv = true
                }
            );


            modelBuilder.Entity<Mekaniker>()
                .HasMany(p => p.Mærker)
                .WithMany(m => m.Mekanikere)
                .UsingEntity<Dictionary<string, object>>(
                    "MekanikerMærke",
                    r => r.HasOne<Mærke>().WithMany().HasForeignKey("MærkeId"),
                    l => l.HasOne<Mekaniker>().WithMany().HasForeignKey("MekanikerId"),
                    je =>
                    {
                        je.HasKey("MekanikerId", "MærkeId");
                        je.HasData(
                            new { MekanikerId = 1, MærkeId = 1 },
                            new { MekanikerId = 1, MærkeId = 4 },
                            new { MekanikerId = 1, MærkeId = 8 },
                            new { MekanikerId = 1, MærkeId = 5 },
                            new { MekanikerId = 1, MærkeId = 2 },
                            new { MekanikerId = 1, MærkeId = 10 },
                            new { MekanikerId = 2, MærkeId = 6 },
                            new { MekanikerId = 2, MærkeId = 3 },
                            new { MekanikerId = 2, MærkeId = 7 },
                            new { MekanikerId = 2, MærkeId = 10 },
                            new { MekanikerId = 3, MærkeId = 2 },
                            new { MekanikerId = 3, MærkeId = 8 },
                            new { MekanikerId = 3, MærkeId = 9 },
                            new { MekanikerId = 3, MærkeId = 10 },
                            new { MekanikerId = 4, MærkeId = 1 },
                            new { MekanikerId = 4, MærkeId = 4 },
                            new { MekanikerId = 4, MærkeId = 5 },
                            new { MekanikerId = 4, MærkeId = 3 },
                            new { MekanikerId = 4, MærkeId = 6 },
                            new { MekanikerId = 4, MærkeId = 7 },
                            new { MekanikerId = 4, MærkeId = 9 });
                    }
                );

            modelBuilder.Entity<By>().HasData(
                new By { Postnummer = "1000", ByNavn = "København" },
                new By { Postnummer = "2000", ByNavn = "Frederiksberg" },
                new By { Postnummer = "3000", ByNavn = "Helsingør" },
                new By { Postnummer = "4000", ByNavn = "Roskilde" },
                new By { Postnummer = "5000", ByNavn = "Odense" },
                new By { Postnummer = "6000", ByNavn = "Kolding" },
                new By { Postnummer = "7000", ByNavn = "Fredericia" },
                new By { Postnummer = "7100", ByNavn = "Vejle" },
                new By { Postnummer = "8000", ByNavn = "Århus" }
            );

            modelBuilder.Entity<Vare>().HasData(
                new Vare { Id = 1, Beskrivelse = "Hjelm", Pris = 500 },
                new Vare { Id = 2, Beskrivelse = "Handsker", Pris = 200 },
                new Vare { Id = 3, Beskrivelse = "Jakke", Pris = 800 },
                new Vare { Id = 4, Beskrivelse = "Bukser", Pris = 600 },
                new Vare { Id = 5, Beskrivelse = "Støvler", Pris = 400 },
                new Vare { Id = 6, Beskrivelse = "Motorolie", Pris = 200 },
                new Vare { Id = 7, Beskrivelse = "Pære (hvid)", Pris = 300 },
                new Vare { Id = 8, Beskrivelse = "Pære (rød)", Pris = 100 },
                new Vare { Id = 9, Beskrivelse = "Pære (orange)", Pris = 200 },
                new Vare { Id = 10, Beskrivelse = "Tændrør", Pris = 50 },
                new Vare { Id = 11, Beskrivelse = "Batteri", Pris = 300 },
                new Vare { Id = 12, Beskrivelse = "Dæk", Pris = 500 },
                new Vare { Id = 13, Beskrivelse = "Fælg", Pris = 400 },
                new Vare { Id = 14, Beskrivelse = "Kædeskærm", Pris = 100 },
                new Vare { Id = 15, Beskrivelse = "Kæde", Pris = 200 },
                new Vare { Id = 16, Beskrivelse = "Mobil holder", Pris = 100 },
                new Vare { Id = 17, Beskrivelse = "GPS", Pris = 300 },
                new Vare { Id = 18, Beskrivelse = "Bluetooth headset", Pris = 200 },
                new Vare { Id = 19, Beskrivelse = "Rygstøtte", Pris = 100 },
                new Vare { Id = 20, Beskrivelse = "Topboks", Pris = 500 }
            );

            modelBuilder.Entity<Ydelse>().HasData(
                new Ydelse { Id = 21, Beskrivelse = "Service", Pris = 500, AntalTimer = 4 },
                new Ydelse { Id = 22, Beskrivelse = "Reparation (u/ reservedele)", Pris = 200, AntalTimer = 1 },
                new Ydelse { Id = 23, Beskrivelse = "Syn", Pris = 300, AntalTimer = 1 },
                new Ydelse { Id = 24, Beskrivelse = "Dækskift", Pris = 100, AntalTimer = 0.25 },
                new Ydelse { Id = 25, Beskrivelse = "Bremse service", Pris = 300, AntalTimer = 1 },
                new Ydelse { Id = 26, Beskrivelse = "Motor service", Pris = 800, AntalTimer = 3 },
                new Ydelse { Id = 27, Beskrivelse = "Elmotor service", Pris = 700, AntalTimer = 3 },
                new Ydelse { Id = 28, Beskrivelse = "Fejlfinding", Pris = 200, AntalTimer = 1 },
                new Ydelse { Id = 29, Beskrivelse = "Rustbeskyttelse", Pris = 1400, AntalTimer = 6 },
                new Ydelse { Id = 30, Beskrivelse = "Lakering", Pris = 2000, AntalTimer = 8 },
                new Ydelse { Id = 31, Beskrivelse = "Polering", Pris = 500, AntalTimer = 2 },
                new Ydelse { Id = 32, Beskrivelse = "Rengøring", Pris = 250, AntalTimer = 1 },
                new Ydelse { Id = 33, Beskrivelse = "Dæktryk tjek", Pris = 50, AntalTimer = 0.15 },
                new Ydelse { Id = 34, Beskrivelse = "Kæde smøring", Pris = 80, AntalTimer = 0.2 },
                new Ydelse { Id = 35, Beskrivelse = "Kæde stramning", Pris = 100, AntalTimer = 0.25 },
                new Ydelse { Id = 36, Beskrivelse = "Kæde skift", Pris = 280, AntalTimer = 1 },
                new Ydelse { Id = 37, Beskrivelse = "Vask", Pris = 100, AntalTimer = 0.25 }
            );

            modelBuilder.Entity<Kunde>().HasData(
                new Kunde
                {
                    KundeId = 1,
                    Navn = "Troels Nielsen",
                    Email = "TrNi@mail.dk",
                    MekanikerId = 1,
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde { 
                    KundeId = 2, 
                    Navn = "Anna Hansen", 
                    Email = "AnnaH@mail.dk", 
                    MekanikerId = 3, 
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde { 
                    KundeId = 3, 
                    Navn = "Peter Jensen", 
                    Email = "PeJe@mail.dk", 
                    MekanikerId = 1, 
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde { 
                    KundeId = 4, 
                    Navn = "Lars Nielsen", 
                    Email = "LaNi@mail.dk", 
                    MekanikerId = 4, 
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde { 
                    KundeId = 5, 
                    Navn = "Mette Sørensen",
                    Email = "MeSo@mail.dk", 
                    MekanikerId = 2, 
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde { 
                    KundeId = 6, 
                    Navn = "Kasper Andersen", 
                    Email = "KaAn@mail.dk", 
                    MekanikerId = 3, 
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde { 
                    KundeId = 7, 
                    Navn = "Sofie Pedersen", 
                    Email = "SoPe@mail.dk", 
                    MekanikerId = 3, 
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde { 
                    KundeId = 8, 
                    Navn = "Jonas Kristensen", 
                    Email = "JoKr@mail.dk", 
                    MekanikerId = 1, 
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde { 
                    KundeId = 9, 
                    Navn = "Camilla Thomsen", 
                    Email = "CaTh@mail.dk", 
                    MekanikerId = 4, 
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde { 
                    KundeId = 10, 
                    Navn = "Frederik Rasmussen", 
                    Email = "FrRa@mail.dk", 
                    MekanikerId = 1, 
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde
                {
                    KundeId = 11,
                    Navn = "Jens Nielsen",
                    Email = "JensNielsen@mail.dk",
                    MekanikerId = 2,
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde
                {
                    KundeId = 12,
                    Navn = "Maja Larsen",
                    Email = "MaLa@mail.dk",
                    MekanikerId = 3,
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde
                {
                    KundeId = 13,
                    Navn = "Nikolaj Møller",
                    Email = "NiMo@mail.dk",
                    MekanikerId = 2,
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde
                {
                    KundeId = 14,
                    Navn = "Julie Olesen",
                    Email = "JuOl@mail.dk",
                    MekanikerId = 1,
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde
                {
                    KundeId = 15,
                    Navn = "Henrik Poulsen",
                    Email = "HePo@mail.dk",
                    MekanikerId = 4,
                    ErAktiv = true,
                    Adresse = null
                },
                new Kunde
                {
                    KundeId = 16,
                    Navn = "Katrine Holm",
                    Email = "KaHo@mail.dk",
                    MekanikerId = 3,
                    ErAktiv = true,
                    Adresse = null
                }
            );

            modelBuilder.Entity<Adresse>().HasData(
                new Adresse
                {
                    AdresseId = 1,
                    Gadenavn = "Hovedgaden",
                    Husnummer = "34",
                    Etage = "3",
                    Side = "tv",
                    Dørnummer = "",
                    Postnummer = "6000",
                    KundeId = 1
                },
                new Adresse
                {
                    AdresseId = 2,
                    Gadenavn = "Borgergade",
                    Husnummer = "12",
                    Etage = "2",
                    Side = "",
                    Dørnummer = "23",
                    Postnummer = "7100",
                    KundeId = 2
                },
                new Adresse
                {
                    AdresseId = 3,
                    Gadenavn = "Vestergade",
                    Husnummer = "45",
                    Etage = "",
                    Side = "",
                    Dørnummer = "",
                    Postnummer = "7000",
                    KundeId = 3
                },
                new Adresse
                {
                    AdresseId = 4,
                    Gadenavn = "Nørregade",
                    Husnummer = "78",
                    Etage = "1",
                    Side = "mf",
                    Dørnummer = "10",
                    Postnummer = "7100",
                    KundeId = 4
                },
                new Adresse
                {
                    AdresseId = 5,
                    Gadenavn = "Østergade",
                    Husnummer = "22",
                    Etage = "4",
                    Side = "th",
                    Dørnummer = "",
                    Postnummer = "6000",
                    KundeId = 5
                },
                new Adresse
                {
                    AdresseId = 6,
                    Gadenavn = "Søndergade",
                    Husnummer = "56",
                    Etage = "",
                    Side = "",
                    Dørnummer = "5",
                    Postnummer = "7100",
                    KundeId = 6
                },
                new Adresse
                {
                    AdresseId = 7,
                    Gadenavn = "Kirkegade",
                    Husnummer = "15",
                    Etage = "2",
                    Side = "tv",
                    Dørnummer = "8",
                    Postnummer = "6000",
                    KundeId = 7
                },
                new Adresse
                {
                    AdresseId = 8,
                    Gadenavn = "Skolegade",
                    Husnummer = "9",
                    Etage = "3",
                    Side = "th",
                    Dørnummer = "",
                    Postnummer = "7000",
                    KundeId = 8
                },
                new Adresse
                {
                    AdresseId = 9,
                    Gadenavn = "Algade",
                    Husnummer = "27",
                    Etage = "",
                    Side = "",
                    Dørnummer = "12",
                    Postnummer = "7100",
                    KundeId = 9
                },
                new Adresse
                {
                    AdresseId = 10,
                    Gadenavn = "Møllevej",
                    Husnummer = "33",
                    Etage = "1",
                    Side = "mf",
                    Dørnummer = "",
                    Postnummer = "6000",
                    KundeId = 10
                },
                new Adresse
                {
                    AdresseId = 11,
                    Gadenavn = "Bakkevej",
                    Husnummer = "5",
                    Etage = "4",
                    Side = "tv",
                    Dørnummer = "7",
                    Postnummer = "7000",
                    KundeId = 11
                },
                new Adresse
                {
                    AdresseId = 12,
                    Gadenavn = "Engvej",
                    Husnummer = "18",
                    Etage = "",
                    Side = "",
                    Dørnummer = "3",
                    Postnummer = "7100",
                    KundeId = 12
                },
                new Adresse
                {
                    AdresseId = 13,
                    Gadenavn = "Lærkevej",
                    Husnummer = "21",
                    Etage = "2",
                    Side = "th",
                    Dørnummer = "",
                    Postnummer = "6000",
                    KundeId = 13
                },
                new Adresse
                {
                    AdresseId = 14,
                    Gadenavn = "Birkevej",
                    Husnummer = "44",
                    Etage = "3",
                    Side = "mf",
                    Dørnummer = "9",
                    Postnummer = "7000",
                    KundeId = 14
                },
                new Adresse
                {
                    AdresseId = 15,
                    Gadenavn = "Fasanvej",
                    Husnummer = "30",
                    Etage = "",
                    Side = "",
                    Dørnummer = "6",
                    Postnummer = "7100",
                    KundeId = 15
                },
                new Adresse
                {
                    AdresseId = 16,
                    Gadenavn = "Solbakken",
                    Husnummer = "12",
                    Etage = "1",
                    Side = "tv",
                    Dørnummer = "",
                    Postnummer = "6000",
                    KundeId = 16
                }
            );

            modelBuilder.Entity<KundeScooter>().HasData(
                new KundeScooter
                {
                    ScooterId = 1,
                    KundeId = 1,
                    Stelnummer = "Kj37h3GS9jOpI800J",
                    Registreringsnummer = "HB3827",
                    MærkeId = 1,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 2,
                    KundeId = 2,
                    Stelnummer = "1HGBH41JXMN109186",
                    Registreringsnummer = "VB7382",
                    MærkeId = 2,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 3,
                    KundeId = 3,
                    Stelnummer = "2HGCM82633A004352",
                    Registreringsnummer = "AF3234",
                    MærkeId = 3,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 4,
                    KundeId = 4,
                    Stelnummer = "1HGCM82633A004353",
                    Registreringsnummer = "CD5634",
                    MærkeId = 4,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 5,
                    KundeId = 5,
                    Stelnummer = "JH4KA8260MC000000",
                    Registreringsnummer = "EF9072",
                    MærkeId = 5,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 6,
                    KundeId = 6,
                    Stelnummer = "1HGCM82633A004354",
                    Registreringsnummer = "GH3656",
                    MærkeId = 6,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 7,
                    KundeId = 7,
                    Stelnummer = "2HGCM82633A004355",
                    Registreringsnummer = "IJ7630",
                    MærkeId = 7,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 8,
                    KundeId = 8,
                    Stelnummer = "1HGCM82633A004356",
                    Registreringsnummer = "KL1533",
                    MærkeId = 8,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 9,
                    KundeId = 9,
                    Stelnummer = "JH4KA8260MC000001",
                    Registreringsnummer = "MN2648",
                    MærkeId = 9,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 10,
                    KundeId = 10,
                    Stelnummer = "1HGCM82633A004357",
                    Registreringsnummer = "OP9314",
                    MærkeId = 10,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 11,
                    KundeId = 11,
                    Stelnummer = "2HGCM82633A004358",
                    Registreringsnummer = "QR5452",
                    MærkeId = 1,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 12,
                    KundeId = 12,
                    Stelnummer = "1HGCM82633A004359",
                    Registreringsnummer = "ST3850",
                    MærkeId = 2,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 13,
                    KundeId = 13,
                    Stelnummer = "JH4KA8260MC000002",
                    Registreringsnummer = "UV2254",
                    MærkeId = 3,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 14,
                    KundeId = 14,
                    Stelnummer = "1HGCM82633A004360",
                    Registreringsnummer = "WX5375",
                    MærkeId = 4,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 15,
                    KundeId = 15,
                    Stelnummer = "2HGCM82633A004361",
                    Registreringsnummer = "YZ3052",
                    MærkeId = 5,
                    ErAktiv = true
                },
                new KundeScooter
                {
                    ScooterId = 16,
                    KundeId = 16,
                    Stelnummer = "1HGCM82633A004362",
                    Registreringsnummer = "AB3651",
                    MærkeId = 6,
                    ErAktiv = true
                }
            );

            modelBuilder.Entity<TlfNummer>().HasData(
                new TlfNummer 
                { 
                    TlfNummerId = 1, 
                    KundeId = 1, 
                    TelefonNummer = "34345678" 
                },
                new TlfNummer 
                { 
                    TlfNummerId = 2,
                    KundeId = 1, 
                    TelefonNummer = "47254321" 
                },
                new TlfNummer
                {
                    TlfNummerId = 3,
                    KundeId = 2,
                    TelefonNummer = "23456789"
                },
                new TlfNummer
                {
                    TlfNummerId = 4,
                    KundeId = 3,
                    TelefonNummer = "34567890"
                },
                new TlfNummer
                {
                    TlfNummerId = 5,
                    KundeId = 4,
                    TelefonNummer = "45678901"
                },
                new TlfNummer
                {
                    TlfNummerId = 6,
                    KundeId = 5,
                    TelefonNummer = "56789012"
                },
                new TlfNummer
                {
                    TlfNummerId = 7,
                    KundeId = 6,
                    TelefonNummer = "67890123"
                },
                new TlfNummer
                {
                    TlfNummerId = 8,
                    KundeId = 7,
                    TelefonNummer = "78901234"
                },
                new TlfNummer
                {
                    TlfNummerId = 9,
                    KundeId = 8,
                    TelefonNummer = "89012345"
                },
                new TlfNummer
                {
                    TlfNummerId = 10,
                    KundeId = 9,
                    TelefonNummer = "90123456"
                },
                new TlfNummer
                {
                    TlfNummerId = 11,
                    KundeId = 10,
                    TelefonNummer = "23456780"
                },
                new TlfNummer
                {
                    TlfNummerId = 12,
                    KundeId = 11,
                    TelefonNummer = "34567891"
                },
                new TlfNummer
                {
                    TlfNummerId = 13,
                    KundeId = 12,
                    TelefonNummer = "45678902"
                },
                new TlfNummer
                {
                    TlfNummerId = 14,
                    KundeId = 13,
                    TelefonNummer = "56789013"
                },
                new TlfNummer
                {
                    TlfNummerId = 15,
                    KundeId = 14,
                    TelefonNummer = "67890124"
                },
                new TlfNummer
                {
                    TlfNummerId = 16,
                    KundeId = 15,
                    TelefonNummer = "78901235"
                },
                new TlfNummer
                {
                    TlfNummerId = 17,
                    KundeId = 16,
                    TelefonNummer = "89012346"
                },
                new TlfNummer
                {
                    TlfNummerId = 18,
                    KundeId = 2,
                    TelefonNummer = "90123457"
                },
                new TlfNummer
                {
                    TlfNummerId = 19,
                    KundeId = 3,
                    TelefonNummer = "23456781"
                },
                new TlfNummer
                {
                    TlfNummerId = 20,
                    KundeId = 4,
                    TelefonNummer = "34567892"
                }
            );

            modelBuilder.Entity<UdlejningsScooter>().HasData(
                new UdlejningsScooter
                {
                    ScooterId = 17,
                    Stelnummer = "1HGCM82633A004363",
                    Registreringsnummer = "CD3654",
                    MærkeId = 1,
                    ErAktiv = true,
                    ErTilgængelig = true
                },
                new UdlejningsScooter
                {
                    ScooterId = 18,
                    Stelnummer = "2HGCM82633A004364",
                    Registreringsnummer = "EF9073",
                    MærkeId = 1,
                    ErAktiv = true,
                    ErTilgængelig = true
                },
                new UdlejningsScooter
                {
                    ScooterId = 19,
                    Stelnummer = "3HGCM82633A004365",
                    Registreringsnummer = "GH1234",
                    MærkeId = 1,
                    ErAktiv = true,
                    ErTilgængelig = false
                },
                new UdlejningsScooter
                {
                    ScooterId = 20,
                    Stelnummer = "4HGCM82633A004366",
                    Registreringsnummer = "IJ5678",
                    MærkeId = 1,
                    ErAktiv = true,
                    ErTilgængelig = true
                },
                new UdlejningsScooter
                {
                    ScooterId = 21,
                    Stelnummer = "5HGCM82633A004367",
                    Registreringsnummer = "KL9012",
                    MærkeId = 1,
                    ErAktiv = true,
                    ErTilgængelig = true
                },
                new UdlejningsScooter
                {
                    ScooterId = 22,
                    Stelnummer = "6HGCM82633A004368",
                    Registreringsnummer = "MN3456",
                    MærkeId = 1,
                    ErAktiv = true,
                    ErTilgængelig = true
                },
                new UdlejningsScooter
                {
                    ScooterId = 23,
                    Stelnummer = "7HGCM82633A004369",
                    Registreringsnummer = "OP7890",
                    MærkeId = 1,
                    ErAktiv = true,
                    ErTilgængelig = true
                }
            );

            modelBuilder.Entity<Ordre>().HasData(
                new Ordre
                {
                    OrdreId = 1,
                    KundeId = 1,
                    StartDato = new DateTime(2024, 12, 1),
                    SlutDato = new DateTime(2024, 12, 3),
                    ErBetalt = true,
                    BetalingsDato = new DateTime(2024, 12, 3),
                    ErAfsluttet = true,
                    KundeScooterId = 1,
                    MekanikerId = 1,
                    Bemærkninger = ""
                },
                new Ordre
                {
                    OrdreId = 2,
                    KundeId = 4,
                    StartDato = DateTime.Now.Date.AddDays(-1),
                    SlutDato = DateTime.Now.Date,
                    ErBetalt = false,
                    ErAfsluttet = false,
                    KundeScooterId = 4,
                    MekanikerId = 4,
                    Bemærkninger = "Dækskifte til nye dæk, samt skifte af kæde."
                },
                new Ordre
                {
                    OrdreId = 3,
                    KundeId = 10,
                    StartDato = DateTime.Now.Date,
                    SlutDato = DateTime.Now.Date,
                    ErBetalt = false,
                    ErAfsluttet = true,
                    Bemærkninger = ""
                }
            );

            modelBuilder.Entity<VareLinje>().HasData(
                new VareLinje
                {
                    VareLinjeId = 1,
                    OrdreId = 1,
                    VareId = 21,
                    Antal = 1,
                    Rabat = 50,
                    VareBeskrivelse = "Service",
                    VarePris = 500,
                    YdelseAntalTimer = 4
                },
                new VareLinje
                {
                    VareLinjeId = 2,
                    OrdreId = 2,
                    VareId = 12,
                    Antal = 2,
                    Rabat = 0,
                    VareBeskrivelse = "Dæk",
                    VarePris = 500
                },
                new VareLinje
                {
                    VareLinjeId = 3,
                    OrdreId = 2,
                    VareId = 24,
                    Antal = 2,
                    Rabat = 25,
                    VareBeskrivelse = "Dækskifte",
                    VarePris = 100,
                    YdelseAntalTimer = 0.25
                },
                new VareLinje
                {
                    VareLinjeId = 4,
                    OrdreId = 2,
                    VareId = 36,
                    Antal = 1,
                    Rabat = 0,
                    VareBeskrivelse = "Kæde skift",
                    VarePris = 280,
                    YdelseAntalTimer = 1
                },
                new VareLinje
                {
                    VareLinjeId = 5,
                    OrdreId = 3,
                    VareId = 1,
                    Antal = 1,
                    Rabat = 0,
                    VareBeskrivelse = "Hjelm",
                    VarePris = 500
                },
                new VareLinje
                {
                    VareLinjeId = 6,
                    OrdreId = 3,
                    VareId = 2,
                    Antal = 1,
                    Rabat = 200,
                    VareBeskrivelse = "Handsker",
                    VarePris = 200
                },
                new VareLinje
                {
                    VareLinjeId = 7,
                    OrdreId = 3,
                    VareId = 3,
                    Antal = 1,
                    Rabat = 0,
                    VareBeskrivelse = "Jakke",
                    VarePris = 800
                },
                new VareLinje
                {
                    VareLinjeId = 8,
                    OrdreId = 3,
                    VareId = 4,
                    Antal = 1,
                    Rabat = 0,
                    VareBeskrivelse = "Bukser",
                    VarePris = 600
                },
                new VareLinje
                {
                    VareLinjeId = 9,
                    OrdreId = 3,
                    VareId = 5,
                    Antal = 1,
                    Rabat = 0,
                    VareBeskrivelse = "Støvler",
                    VarePris = 400
                }
            );

            modelBuilder.Entity<Udlejning>().HasData(
                new Udlejning
                {
                    UdlejningId = 1,
                    UdlejningsScooterId = 17,
                    OrdreId = 1,
                    StartDato = new DateTime(2024, 12, 1),
                    SlutDato = new DateTime(2024, 12, 3),
                    AntalKmKørt = 14,
                    SelvrisikoUdløst = true
                },
                new Udlejning
                {
                    UdlejningId = 2,
                    UdlejningsScooterId = 19,
                    OrdreId = 2,
                    StartDato = DateTime.Now.Date.AddDays(-1),
                    SlutDato = DateTime.Now.Date,
                    AntalKmKørt = 0,
                    SelvrisikoUdløst = false
                }
            );
        }
    }
}
