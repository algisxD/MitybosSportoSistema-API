﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MitybosSportoSistema_API.Data;

namespace MitybosSportoSistema_API.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210224132622_SportoPrograma")]
    partial class SportoPrograma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Data.Produktas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Angliavandeniai")
                        .HasColumnType("float");

                    b.Property<double>("Baltymai")
                        .HasColumnType("float");

                    b.Property<double>("Druska")
                        .HasColumnType("float");

                    b.Property<double>("Kcal")
                        .HasColumnType("float");

                    b.Property<string>("Pavadinimas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Riebalai")
                        .HasColumnType("float");

                    b.Property<double>("Vanduo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Produktai");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Infrastructure.Database.Models.SportoPrograma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pavadinimas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VartotojasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VartotojasId");

                    b.ToTable("SportoPrograma");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int?>("VartotojasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("VartotojasId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.Ingridientas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Kiekis")
                        .HasColumnType("float");

                    b.Property<int?>("ProduktasId")
                        .HasColumnType("int");

                    b.Property<int?>("ReceptasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProduktasId");

                    b.HasIndex("ReceptasId");

                    b.ToTable("Ingridientai");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.Pratimas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aprasymas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PakartojimuSkaicius")
                        .HasColumnType("int");

                    b.Property<string>("Pavadinimas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SerijuSkaicius")
                        .HasColumnType("int");

                    b.Property<int?>("TreniruoteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TreniruoteId");

                    b.ToTable("Pratimai");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.Receptas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aprasymas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GaminimoLaikas")
                        .HasColumnType("int");

                    b.Property<int>("Kcal")
                        .HasColumnType("int");

                    b.Property<string>("Nuotrauka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pavadinimas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PorcijuSkaicius")
                        .HasColumnType("int");

                    b.Property<int?>("VartotojasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VartotojasId");

                    b.ToTable("Receptai");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.Treniruote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pavadinimas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SavaitesDiena")
                        .HasColumnType("int");

                    b.Property<int?>("SportoProgramaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SportoProgramaId");

                    b.ToTable("Treniruotes");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.Vartotojas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pavarde")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Svoris")
                        .HasColumnType("int");

                    b.Property<int>("Ugis")
                        .HasColumnType("int");

                    b.Property<string>("Vardas")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vartotojai");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MitybosSportoSistema_API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MitybosSportoSistema_API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MitybosSportoSistema_API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MitybosSportoSistema_API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Infrastructure.Database.Models.SportoPrograma", b =>
                {
                    b.HasOne("MitybosSportoSistema_API.Models.Vartotojas", "Vartotojas")
                        .WithMany("SportoProgramos")
                        .HasForeignKey("VartotojasId");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.ApplicationUser", b =>
                {
                    b.HasOne("MitybosSportoSistema_API.Models.Vartotojas", "Vartotojas")
                        .WithMany()
                        .HasForeignKey("VartotojasId");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.Ingridientas", b =>
                {
                    b.HasOne("MitybosSportoSistema_API.Data.Produktas", "Produktas")
                        .WithMany("Ingridientai")
                        .HasForeignKey("ProduktasId");

                    b.HasOne("MitybosSportoSistema_API.Models.Receptas", null)
                        .WithMany("Ingridientai")
                        .HasForeignKey("ReceptasId");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.Pratimas", b =>
                {
                    b.HasOne("MitybosSportoSistema_API.Models.Treniruote", null)
                        .WithMany("DaromiPratimai")
                        .HasForeignKey("TreniruoteId");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.Receptas", b =>
                {
                    b.HasOne("MitybosSportoSistema_API.Models.Vartotojas", "Vartotojas")
                        .WithMany("Receptai")
                        .HasForeignKey("VartotojasId");
                });

            modelBuilder.Entity("MitybosSportoSistema_API.Models.Treniruote", b =>
                {
                    b.HasOne("MitybosSportoSistema_API.Infrastructure.Database.Models.SportoPrograma", null)
                        .WithMany("Treniruotes")
                        .HasForeignKey("SportoProgramaId");
                });
#pragma warning restore 612, 618
        }
    }
}
