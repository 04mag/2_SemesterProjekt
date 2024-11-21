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
            modelBuilder.Entity<Scooter>().HasDiscriminator<string>("ScooterType").HasValue<KundeScooter>("KundeScooter").HasValue<UdlejningsScooter>("UdlejningsScooter");

            modelBuilder.Entity<Scooter>().ToTable("Scootere");
            

            // Oprette separate tabeller for hver Type.



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

            modelBuilder.Entity<Scooter>()
                .HasOne(s => s.Mærke)  // Hver Scooter har et Mærke
                .WithMany(m => m.Scootere)  // Hvert Mærke har mange Scootere
                .HasForeignKey(s => s.MærkeId)  // Uden denne linje, vil EF Core oprette en ekstra kolonne i Scooter-tabellen
                .OnDelete(DeleteBehavior.Restrict);  // Forhindrer sletning af Mærke, hvis der er Scootere tilknyttet

            modelBuilder.Entity<Mekaniker>().HasData(
                new Mekaniker
                {
                    MekanikerId = 1,
                    Navn = "Troels Nielsen",
                    ErAktiv = true
                },
                new Mekaniker { 
                    MekanikerId = 2, 
                    Navn = "Mads Jensen", 
                    ErAktiv = true
                },
                new Mekaniker { 
                    MekanikerId = 3, 
                    Navn = "Mikkel Larsen", 
                    ErAktiv = true
                },
                new Mekaniker { 
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
            });

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

        }
    }
}
