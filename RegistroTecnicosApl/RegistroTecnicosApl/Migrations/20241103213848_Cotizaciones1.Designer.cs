﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicosApl.DAL;

#nullable disable

namespace RegistroTecnicosApl.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241103213848_Cotizaciones1")]
    partial class Cotizaciones1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RegistroTecnicosApl.Models.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"));

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Costo = 2200.0,
                            Descripcion = "Router Wi-Fi 6",
                            Existencia = 50,
                            Precio = 3500.0
                        },
                        new
                        {
                            ArticuloId = 2,
                            Costo = 7000.0,
                            Descripcion = "Pantalla OLED",
                            Existencia = 75,
                            Precio = 9500.0
                        },
                        new
                        {
                            ArticuloId = 3,
                            Costo = 2500.0,
                            Descripcion = "tinta para impresora",
                            Existencia = 80,
                            Precio = 3500.0
                        },
                        new
                        {
                            ArticuloId = 4,
                            Costo = 2500.0,
                            Descripcion = "Disco duro",
                            Existencia = 50,
                            Precio = 4000.0
                        },
                        new
                        {
                            ArticuloId = 5,
                            Costo = 2000.0,
                            Descripcion = "Router",
                            Existencia = 150,
                            Precio = 3000.0
                        },
                        new
                        {
                            ArticuloId = 6,
                            Costo = 7500.0,
                            Descripcion = "Camara de vigilancia",
                            Existencia = 100,
                            Precio = 9500.0
                        },
                        new
                        {
                            ArticuloId = 7,
                            Costo = 4000.0,
                            Descripcion = "Switch de red ",
                            Existencia = 25,
                            Precio = 6000.0
                        });
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Cotizaciones", b =>
                {
                    b.Property<int>("CotizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CotizacionId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CotizacionId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.CotizacionesDetalle", b =>
                {
                    b.Property<int>("CotizacionDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CotizacionDetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("ArticulosArticuloId")
                        .HasColumnType("int");

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<int>("CotizacionId")
                        .HasColumnType("int");

                    b.Property<int>("CotizacionesCotizacionId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("CotizacionDetalleId");

                    b.HasIndex("ArticulosArticuloId");

                    b.HasIndex("CotizacionesCotizacionId");

                    b.ToTable("CotizacionesDetalle");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Prioridades", b =>
                {
                    b.Property<int>("PrioridadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrioridadId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Tiempo")
                        .HasColumnType("time");

                    b.HasKey("PrioridadId");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TecnicoId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SueldoHora")
                        .HasColumnType("float");

                    b.Property<int>("TipoTecnicoId")
                        .HasColumnType("int");

                    b.HasKey("TecnicoId");

                    b.HasIndex("TipoTecnicoId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.TiposTecnicos", b =>
                {
                    b.Property<int>("TipoTecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoTecnicoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoTecnicoId");

                    b.ToTable("TiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Trabajos", b =>
                {
                    b.Property<int>("TrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrabajoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<int>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("int");

                    b.HasKey("TrabajoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.TrabajosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("TrabajoId")
                        .HasColumnType("int");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("TrabajoId");

                    b.ToTable("TrabajoDetalle");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Cotizaciones", b =>
                {
                    b.HasOne("RegistroTecnicosApl.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.CotizacionesDetalle", b =>
                {
                    b.HasOne("RegistroTecnicosApl.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticulosArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicosApl.Models.Cotizaciones", "Cotizaciones")
                        .WithMany("CotizacionesDetalles")
                        .HasForeignKey("CotizacionesCotizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulos");

                    b.Navigation("Cotizaciones");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Tecnicos", b =>
                {
                    b.HasOne("RegistroTecnicosApl.Models.TiposTecnicos", "TipoTecnico")
                        .WithMany()
                        .HasForeignKey("TipoTecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoTecnico");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Trabajos", b =>
                {
                    b.HasOne("RegistroTecnicosApl.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicosApl.Models.Prioridades", "Prioridades")
                        .WithMany()
                        .HasForeignKey("PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicosApl.Models.Tecnicos", "Tecnicos")
                        .WithMany()
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Prioridades");

                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.TrabajosDetalle", b =>
                {
                    b.HasOne("RegistroTecnicosApl.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicosApl.Models.Trabajos", "Trabajos")
                        .WithMany("TrabajoDetalle")
                        .HasForeignKey("TrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulos");

                    b.Navigation("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Cotizaciones", b =>
                {
                    b.Navigation("CotizacionesDetalles");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Trabajos", b =>
                {
                    b.Navigation("TrabajoDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
