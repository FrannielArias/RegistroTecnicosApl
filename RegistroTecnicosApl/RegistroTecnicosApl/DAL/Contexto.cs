using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.Models;
using RegistroTecnicosApl.Services;

namespace RegistroTecnicosApl.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) 
            : base(options){ }

        public DbSet<Tecnicos> Tecnicos { get; set; }
        public DbSet<TiposTecnicos> TiposTecnicos { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Trabajos> Trabajos { get; set; }

        public DbSet<Prioridades> Prioridades { get; set; }

        public DbSet<TrabajosDetalle> TrabajoDetalle { get; set; }

        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>().HasData(
                new List<Articulos>()
                {
                new()
                {
                    ArticuloId = 1,
                    Descripcion = "Router Wi-Fi 6",
                    Costo = 2200,
                    Precio = 3500,
                    Existencia = 50,

                },

                new() {

                    ArticuloId = 2,
                    Descripcion = "Pantalla OLED",
                    Costo = 7000,
                    Precio = 9500,
                    Existencia = 75,

                },

                new()
                {
                    ArticuloId = 3,
                    Descripcion = "tinta para impresora",
                    Costo = 2500,
                    Precio = 3500,
                    Existencia = 80,

                },

                new() {
                    ArticuloId = 4,
                    Descripcion = "Disco duro",
                    Costo = 2500,
                    Precio = 4000,
                    Existencia = 50,
                },

                new() {
                    ArticuloId = 5,
                    Descripcion = "Router",
                    Costo = 2000,
                    Precio = 3000,
                    Existencia = 150,
                },

                new() {
                    ArticuloId = 6,
                    Descripcion = "Camara de vigilancia",
                    Costo = 7500,
                    Precio = 9500,
                    Existencia = 100,
                },
                new() {
                    ArticuloId = 7,
                    Descripcion = "Switch de red ",
                    Costo = 4000,
                    Precio = 6000,
                    Existencia = 25,
                }
                }

             );
            base.OnModelCreating(modelBuilder);

        }
    }

}
