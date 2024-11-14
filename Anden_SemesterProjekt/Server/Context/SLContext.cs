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
            modelBuilder.Entity<KundeScooter>().ToTable("KundeScootere");
            modelBuilder.Entity<UdlejningsScooter>().ToTable("UdlejningsScootere");
            modelBuilder.Entity<Vare>().ToTable("Varer");
            modelBuilder.Entity<Ydelse>().ToTable("Ydelser");
        }
    }
}
