using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class PrioridadesServices
{
    private readonly Contexto _contexto;

    public PrioridadesServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Guardar(Prioridades prioridad)
    {
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
        return await _contexto.Prioridades
            .AnyAsync(p => p.PrioridadId == prioridadId);
    }
    private async Task<bool> Insertar(Prioridades prioridad)
    {
        _contexto.Prioridades.Add(prioridad);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prioridades prioridad)
    {
        _contexto.Update(prioridad);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(Prioridades prioridad)
    {
        return await _contexto.Prioridades
            .AsNoTracking()
            .Where(p => p.PrioridadId == prioridad.PrioridadId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Prioridades?> Buscar(int prioridadId)
    {
        return await _contexto.Prioridades
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PrioridadId == prioridadId);
    }

    public async Task<bool> ExistePrioridad(int id, string descripcion)
    {
        return await _contexto.Prioridades.AnyAsync(p => p.PrioridadId == id
        && p.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        return await _contexto.Prioridades
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
