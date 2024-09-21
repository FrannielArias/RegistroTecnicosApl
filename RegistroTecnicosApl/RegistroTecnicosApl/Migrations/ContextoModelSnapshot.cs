﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicosApl.DAL;

#nullable disable

namespace RegistroTecnicosApl.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("RegistroTecnicosApl.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Prioridades", b =>
                {
                    b.Property<int>("PrioridadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Tiempo")
                        .HasColumnType("TEXT");

                    b.HasKey("PrioridadId");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SueldoHora")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoTecnicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TecnicoId");

                    b.HasIndex("TipoTecnicoId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.TiposTecnicos", b =>
                {
                    b.Property<int>("TipoTecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TipoTecnicoId");

                    b.ToTable("TiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicosApl.Models.Trabajos", b =>
                {
                    b.Property<int>("TrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TrabajoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("Trabajos");
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
                    b.HasOne("RegistroTecnicosApl.Models.Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicosApl.Models.Tecnicos", "tecnicos")
                        .WithMany()
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("tecnicos");
                });
#pragma warning restore 612, 618
        }
    }
}