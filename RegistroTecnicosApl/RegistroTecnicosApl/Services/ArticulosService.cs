using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services
{
    public class ArticulosService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();
            return await _contexto.Articulos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
