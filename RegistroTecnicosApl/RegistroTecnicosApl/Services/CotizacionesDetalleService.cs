using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class CotizacionesDetalleService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<CotizacionesDetalle>> Listar(Expression<Func<CotizacionesDetalle, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.CotizacionesDetalle
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
