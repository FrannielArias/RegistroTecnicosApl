using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.Models;

namespace RegistroTecnicosApl.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) 
            : base(options){ }

        public DbSet<Tecnicos> Tecnicos { get; set; }
        public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
    }
}
