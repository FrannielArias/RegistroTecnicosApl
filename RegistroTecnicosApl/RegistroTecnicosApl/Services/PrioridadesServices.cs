using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class PrioridadesServices(IDbContextFactory<Contexto> DbFactory)
{

    public async Task<bool> Guardar(Prioridades prioridad)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(prioridad.PrioridadId))
        {
            return await Insertar(prioridad);
        }
        else
        {
            return await Modificar(prioridad);
        }
    }
    private async Task<bool> Existe(int prioridadId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Prioridades
            .AnyAsync(p => p.PrioridadId == prioridadId);
    }
    private async Task<bool> Insertar(Prioridades prioridad)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Prioridades.Add(prioridad);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prioridades prioridad)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(prioridad);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(Prioridades prioridad)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Prioridades
            .AsNoTracking()
            .Where(p => p.PrioridadId == prioridad.PrioridadId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Prioridades?> Buscar(int prioridadId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        
        return await _contexto.Prioridades
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PrioridadId == prioridadId);
    }

    public async Task<bool> ExistePrioridad(int id, string descripcion)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Prioridades.AnyAsync(p => p.PrioridadId == id
        && p.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Prioridades
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
