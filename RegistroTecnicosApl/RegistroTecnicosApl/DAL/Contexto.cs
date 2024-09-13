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
    }
}
