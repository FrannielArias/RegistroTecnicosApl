using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.ComponentModel;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class TrabajosServices
{
    private readonly Contexto _contexto;

    public TrabajosServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Guardar(Trabajos trabajo)
    {
        if (!await Existe(trabajo.TrabajoId))
        {
            return await Insertar(trabajo);
        }
        else
        {
            return await Modificar(trabajo);
        }
    }
    private async Task<bool> Existe(int trabajoId)
    {
        return await _contexto.Trabajos
            .AnyAsync(t => t.TrabajoId == trabajoId);
    }
    private async Task<bool> Insertar(Trabajos trabajo)
    {
        _contexto.Add(trabajo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Trabajos trabajo)
    {
        _contexto.Update(trabajo);
        return await _contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(Trabajos trabajo)
    {
        return await _contexto.Trabajos
            .AsNoTracking()
            .Where(t => t.TrabajoId == trabajo.TrabajoId)
            .ExecuteDeleteAsync() > 0;
    }
        
    public async Task<Trabajos?> Buscar(int trabajoId)
    {
        return await _contexto.Trabajos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TrabajoId == trabajoId);
    }
    public async Task<Trabajos?> BuscarTodo(int trabajoId)
    {
        return await _contexto.Trabajos
            .Include(t => t.tecnicos)
            .Include(c => c.Cliente)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TrabajoId == trabajoId);
    }

    public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
    {
        return await _contexto.Trabajos
            .Include(t => t.tecnicos)
            .Include(c => c.Cliente)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
