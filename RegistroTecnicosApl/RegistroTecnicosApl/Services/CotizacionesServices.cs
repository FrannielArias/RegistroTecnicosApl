using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using SQLitePCL;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class CotizacionesServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Cotizaciones cotizaciones)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(cotizaciones.CotizacionId))
        {
            return await Insertar(cotizaciones);
        }
        else
        {
            return await Modificar(cotizaciones);
        }
    }

    private async Task<bool> Modificar(Cotizaciones cotizaciones)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Cotizaciones.Update(cotizaciones);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Insertar(Cotizaciones cotizaciones)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        _contexto.Add(cotizaciones);
        return await _contexto.SaveChangesAsync() > 0;

    }

    private async Task<bool> Existe(int cotizacionId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Cotizaciones
            .AnyAsync(c => c.CotizacionId == cotizacionId);
    }

    public async Task<Cotizaciones?> Buscar(int cotizacionId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Cotizaciones
            .Include(c => c.Clientes)
            .AsNoTracking()
            .FirstOrDefaultAsync(c=> c.CotizacionId == cotizacionId);
    }

    public async Task<bool> Eliminar(Cotizaciones cotizaciones)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Cotizaciones
            .AsNoTracking()
            .Where(c=> c.CotizacionId == cotizaciones.CotizacionId)
            .ExecuteDeleteAsync() > 0;    
    }

    public async Task<List<Cotizaciones>> Listar(Expression<Func<Cotizaciones, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Cotizaciones
            .Include(c => c.Clientes)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<CotizacionesDetalle>> BuscarDetalle(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.CotizacionesDetalle
            .Include(td => td.Articulos)
            .AsNoTracking()
            .Where(cd => cd.CotizacionId == id)
            .ToListAsync();
    }
}
