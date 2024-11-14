﻿// <auto-generated />
using System;
using Anden_SemesterProjekt.Server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    [DbContext(typeof(SLContext))]
    partial class SLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Adresse", b =>
                {
                    b.Property<int>("AdresseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdresseId"));

                    b.Property<int>("ByPostnummer")
                        .HasColumnType("int");

                    b.Property<string>("Dørnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Etage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gadenavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Husnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KundeId")
                        .HasColumnType("int");

                    b.Property<string>("Postnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Side")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdresseId");

                    b.HasIndex("ByPostnummer");

                    b.HasIndex("KundeId")
                        .IsUnique();

                    b.ToTable("Adresser");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.By", b =>
                {
                    b.Property<int>("Postnummer")
                        .HasColumnType("int");

                    b.Property<string>("ByNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Postnummer");

                    b.ToTable("By");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Kunde", b =>
                {
                    b.Property<int>("KundeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KundeId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TilknyttetMekanikerMekanikerId")
                        .HasColumnType("int");

                    b.HasKey("KundeId");

                    b.HasIndex("TilknyttetMekanikerMekanikerId");

                    b.ToTable("Kunder");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Mekaniker", b =>
                {
                    b.Property<int>("MekanikerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MekanikerId"));

                    b.Property<bool>("ErAktiv")
                        .HasColumnType("bit");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MekanikerId");

                    b.ToTable("Mekanikere");

                    b.HasData(
                        new
                        {
                            MekanikerId = 1,
                            ErAktiv = true,
                            Navn = "Troels Nielsen"
                        },
                        new
                        {
                            MekanikerId = 2,
                            ErAktiv = true,
                            Navn = "Mads Jensen"
                        },
                        new
                        {
                            MekanikerId = 3,
                            ErAktiv = true,
                            Navn = "Mikkel Larsen"
                        },
                        new
                        {
                            MekanikerId = 4,
                            ErAktiv = true,
                            Navn = "Anders Pedersen"
                        });
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Mærke", b =>
                {
                    b.Property<int>("MærkeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MærkeId"));

                    b.Property<string>("ScooterMærke")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MærkeId");

                    b.ToTable("Mærker");

                    b.HasData(
                        new
                        {
                            MærkeId = 1,
                            ScooterMærke = "Aprilla"
                        },
                        new
                        {
                            MærkeId = 2,
                            ScooterMærke = "Derbi"
                        },
                        new
                        {
                            MærkeId = 3,
                            ScooterMærke = "Karma"
                        },
                        new
                        {
                            MærkeId = 4,
                            ScooterMærke = "Lindebjerg"
                        },
                        new
                        {
                            MærkeId = 5,
                            ScooterMærke = "Pegasus"
                        },
                        new
                        {
                            MærkeId = 6,
                            ScooterMærke = "Peugeot"
                        },
                        new
                        {
                            MærkeId = 7,
                            ScooterMærke = "PGO"
                        },
                        new
                        {
                            MærkeId = 8,
                            ScooterMærke = "Puch"
                        },
                        new
                        {
                            MærkeId = 9,
                            ScooterMærke = "Vespa"
                        },
                        new
                        {
                            MærkeId = 10,
                            ScooterMærke = "Yamaha"
                        });
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Ordre", b =>
                {
                    b.Property<int>("OrdreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdreId"));

                    b.Property<string>("Bemærkninger")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BetalingsDato")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ErAfsluttet")
                        .HasColumnType("bit");

                    b.Property<bool>("ErBetalt")
                        .HasColumnType("bit");

                    b.Property<int?>("KundeId")
                        .HasColumnType("int");

                    b.Property<int?>("KundeScooterId")
                        .HasColumnType("int");

                    b.Property<int?>("MekanikerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SlutDato")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDato")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UdlejningsScooterId")
                        .HasColumnType("int");

                    b.HasKey("OrdreId");

                    b.HasIndex("KundeId");

                    b.HasIndex("KundeScooterId");

                    b.HasIndex("MekanikerId");

                    b.HasIndex("UdlejningsScooterId");

                    b.ToTable("Ordrer");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Scooter", b =>
                {
                    b.Property<int>("ScooterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScooterId"));

                    b.Property<int>("MærkeId")
                        .HasColumnType("int");

                    b.Property<string>("Registreiringsnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stelnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScooterId");

                    b.HasIndex("MærkeId");

                    b.ToTable("Scootere");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.TlfNummer", b =>
                {
                    b.Property<int>("TlfNummerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TlfNummerId"));

                    b.Property<int>("KundeId")
                        .HasColumnType("int");

                    b.Property<string>("TelefonNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TlfNummerId");

                    b.HasIndex("KundeId");

                    b.ToTable("TlfNumre");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Udlejning", b =>
                {
                    b.Property<int>("UdlejningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UdlejningId"));

                    b.Property<double>("AntalKmKørt")
                        .HasColumnType("float");

                    b.Property<double>("ForsikringPrDag")
                        .HasColumnType("float");

                    b.Property<double>("LejePrDag")
                        .HasColumnType("float");

                    b.Property<int>("OrdreId")
                        .HasColumnType("int");

                    b.Property<double>("PrisPrKm")
                        .HasColumnType("float");

                    b.Property<double>("Selvrisiko")
                        .HasColumnType("float");

                    b.Property<bool>("SelvrisikoUdløst")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SlutDato")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDato")
                        .HasColumnType("datetime2");

                    b.Property<int>("UdlejningsScooterId")
                        .HasColumnType("int");

                    b.HasKey("UdlejningId");

                    b.HasIndex("OrdreId");

                    b.HasIndex("UdlejningsScooterId");

                    b.ToTable("Udlejninger");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Vare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ErAktiv")
                        .HasColumnType("bit");

                    b.Property<double>("Pris")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Varer", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.VareLinje", b =>
                {
                    b.Property<int>("VareLinjeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VareLinjeId"));

                    b.Property<int>("Antal")
                        .HasColumnType("int");

                    b.Property<int>("OrdreId")
                        .HasColumnType("int");

                    b.Property<double?>("Rabat")
                        .HasColumnType("float");

                    b.Property<int>("VareId")
                        .HasColumnType("int");

                    b.Property<double>("VarePris")
                        .HasColumnType("float");

                    b.HasKey("VareLinjeId");

                    b.HasIndex("OrdreId");

                    b.HasIndex("VareId");

                    b.ToTable("VareLinjer");
                });

            modelBuilder.Entity("MekanikerMærke", b =>
                {
                    b.Property<int>("MekanikerId")
                        .HasColumnType("int");

                    b.Property<int>("MærkeId")
                        .HasColumnType("int");

                    b.HasKey("MekanikerId", "MærkeId");

                    b.HasIndex("MærkeId");

                    b.ToTable("MekanikerMærke");

                    b.HasData(
                        new
                        {
                            MekanikerId = 1,
                            MærkeId = 1
                        },
                        new
                        {
                            MekanikerId = 1,
                            MærkeId = 4
                        },
                        new
                        {
                            MekanikerId = 1,
                            MærkeId = 8
                        },
                        new
                        {
                            MekanikerId = 1,
                            MærkeId = 5
                        },
                        new
                        {
                            MekanikerId = 1,
                            MærkeId = 2
                        },
                        new
                        {
                            MekanikerId = 1,
                            MærkeId = 10
                        },
                        new
                        {
                            MekanikerId = 2,
                            MærkeId = 6
                        },
                        new
                        {
                            MekanikerId = 2,
                            MærkeId = 3
                        },
                        new
                        {
                            MekanikerId = 2,
                            MærkeId = 7
                        },
                        new
                        {
                            MekanikerId = 2,
                            MærkeId = 10
                        },
                        new
                        {
                            MekanikerId = 3,
                            MærkeId = 2
                        },
                        new
                        {
                            MekanikerId = 3,
                            MærkeId = 8
                        },
                        new
                        {
                            MekanikerId = 3,
                            MærkeId = 9
                        },
                        new
                        {
                            MekanikerId = 3,
                            MærkeId = 10
                        },
                        new
                        {
                            MekanikerId = 4,
                            MærkeId = 1
                        },
                        new
                        {
                            MekanikerId = 4,
                            MærkeId = 4
                        },
                        new
                        {
                            MekanikerId = 4,
                            MærkeId = 5
                        },
                        new
                        {
                            MekanikerId = 4,
                            MærkeId = 3
                        },
                        new
                        {
                            MekanikerId = 4,
                            MærkeId = 6
                        },
                        new
                        {
                            MekanikerId = 4,
                            MærkeId = 7
                        },
                        new
                        {
                            MekanikerId = 4,
                            MærkeId = 9
                        });
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.KundeScooter", b =>
                {
                    b.HasBaseType("Anden_SemesterProjekt.Shared.Models.Scooter");

                    b.Property<int>("KundeId")
                        .HasColumnType("int");

                    b.HasIndex("KundeId");

                    b.ToTable("KundeScootere", (string)null);
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.UdlejningsScooter", b =>
                {
                    b.HasBaseType("Anden_SemesterProjekt.Shared.Models.Scooter");

                    b.Property<bool>("ErAktiv")
                        .HasColumnType("bit");

                    b.Property<bool>("ErTilgængelig")
                        .HasColumnType("bit");

                    b.ToTable("UdlejningsScootere", (string)null);
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Ydelse", b =>
                {
                    b.HasBaseType("Anden_SemesterProjekt.Shared.Models.Vare");

                    b.Property<double>("AntalTimer")
                        .HasColumnType("float");

                    b.ToTable("Ydelser", (string)null);
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Adresse", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.By", "By")
                        .WithMany("Adresser")
                        .HasForeignKey("ByPostnummer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Kunde", "Kunde")
                        .WithOne("Adresse")
                        .HasForeignKey("Anden_SemesterProjekt.Shared.Models.Adresse", "KundeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("By");

                    b.Navigation("Kunde");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Kunde", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Mekaniker", "TilknyttetMekaniker")
                        .WithMany()
                        .HasForeignKey("TilknyttetMekanikerMekanikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TilknyttetMekaniker");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Ordre", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Kunde", "Kunde")
                        .WithMany("Ordrer")
                        .HasForeignKey("KundeId");

                    b.HasOne("Anden_SemesterProjekt.Shared.Models.KundeScooter", "KundeScooter")
                        .WithMany()
                        .HasForeignKey("KundeScooterId");

                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Mekaniker", "Mekaniker")
                        .WithMany("Ordrer")
                        .HasForeignKey("MekanikerId");

                    b.HasOne("Anden_SemesterProjekt.Shared.Models.UdlejningsScooter", "UdlejningsScooter")
                        .WithMany()
                        .HasForeignKey("UdlejningsScooterId");

                    b.Navigation("Kunde");

                    b.Navigation("KundeScooter");

                    b.Navigation("Mekaniker");

                    b.Navigation("UdlejningsScooter");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Scooter", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Mærke", "Mærke")
                        .WithMany("Scootere")
                        .HasForeignKey("MærkeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mærke");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.TlfNummer", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Kunde", "Kunde")
                        .WithMany("TlfNumre")
                        .HasForeignKey("KundeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kunde");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Udlejning", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Ordre", "Ordre")
                        .WithMany()
                        .HasForeignKey("OrdreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anden_SemesterProjekt.Shared.Models.UdlejningsScooter", "UdlejningsScooter")
                        .WithMany("Udlejninger")
                        .HasForeignKey("UdlejningsScooterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ordre");

                    b.Navigation("UdlejningsScooter");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.VareLinje", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Ordre", "Ordre")
                        .WithMany("VareLinjer")
                        .HasForeignKey("OrdreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Vare", "Vare")
                        .WithMany("VareLinjer")
                        .HasForeignKey("VareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ordre");

                    b.Navigation("Vare");
                });

            modelBuilder.Entity("MekanikerMærke", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Mekaniker", null)
                        .WithMany()
                        .HasForeignKey("MekanikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Mærke", null)
                        .WithMany()
                        .HasForeignKey("MærkeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.KundeScooter", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Kunde", "Kunde")
                        .WithMany("Scootere")
                        .HasForeignKey("KundeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Scooter", null)
                        .WithOne()
                        .HasForeignKey("Anden_SemesterProjekt.Shared.Models.KundeScooter", "ScooterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kunde");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.UdlejningsScooter", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Scooter", null)
                        .WithOne()
                        .HasForeignKey("Anden_SemesterProjekt.Shared.Models.UdlejningsScooter", "ScooterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Ydelse", b =>
                {
                    b.HasOne("Anden_SemesterProjekt.Shared.Models.Vare", null)
                        .WithOne()
                        .HasForeignKey("Anden_SemesterProjekt.Shared.Models.Ydelse", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.By", b =>
                {
                    b.Navigation("Adresser");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Kunde", b =>
                {
                    b.Navigation("Adresse")
                        .IsRequired();

                    b.Navigation("Ordrer");

                    b.Navigation("Scootere");

                    b.Navigation("TlfNumre");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Mekaniker", b =>
                {
                    b.Navigation("Ordrer");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Mærke", b =>
                {
                    b.Navigation("Scootere");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Ordre", b =>
                {
                    b.Navigation("VareLinjer");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.Vare", b =>
                {
                    b.Navigation("VareLinjer");
                });

            modelBuilder.Entity("Anden_SemesterProjekt.Shared.Models.UdlejningsScooter", b =>
                {
                    b.Navigation("Udlejninger");
                });
#pragma warning restore 612, 618
        }
    }
}
