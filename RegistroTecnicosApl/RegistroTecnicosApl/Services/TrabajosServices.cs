using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.ComponentModel;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class TrabajosServices(IDbContextFactory<Contexto> DbFactory)
{

    public async Task<bool> Guardar(Trabajos trabajo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(trabajo.TrabajoId))
        {
            foreach (var detalle in trabajo.TrabajoDetalle)
            {
                var articulo = await BuscarArticulos(detalle.ArticuloId);
                if (articulo != null)
                {
                    articulo.Existencia -= detalle.Cantidad;
                    await ActualizarArticulo(articulo);
                }
            }
            return await Insertar(trabajo);

        }
        else
            return await Modificar(trabajo);
    }
    private async Task<bool> Existe(int trabajoId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Trabajos
            .AnyAsync(t => t.TrabajoId == trabajoId);
    }
    private async Task<bool> Insertar(Trabajos trabajo)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Add(trabajo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Trabajos trabajo)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(trabajo);
        return await _contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(Trabajos trabajo)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Trabajos
            .AsNoTracking()
            .Where(t => t.TrabajoId == trabajo.TrabajoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Trabajos?> Buscar(int trabajoId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Trabajos
            .Include(t => t.Tecnicos)
            .Include(c => c.Clientes)
            .Include(p => p.Prioridades)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TrabajoId == trabajoId);
    }
    public async Task<Trabajos?> BuscarTodo(int trabajoId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Trabajos
            .Include(t => t.TrabajoId)
            .Include(c => c.Clientes)
            .Include(p => p.Prioridades)
            .Include(d => d.TrabajoDetalle)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TrabajoId == trabajoId);
    }

    public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Trabajos
            .Include(d => d.TrabajoDetalle)
            .Include(t => t.Tecnicos)
            .Include(c => c.Clientes)
            .Include(p => p.Prioridades)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<Articulos>> ListarArticulos()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Articulos
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<TrabajosDetalle>> ListarDetalle(int trabajoId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        var detalle = await _contexto.TrabajoDetalle
            .Where(d => d.TrabajoId == trabajoId)
            .ToListAsync();

        return detalle;
    }
    public async Task<List<TrabajosDetalle>> BuscarDetalle(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.TrabajoDetalle
            .Include(td => td.Articulos)
            .AsNoTracking()
            .Where(td => td.TrabajoId == id)
            .ToListAsync();
    }
    public async Task<Articulos> BuscarArticulos(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.ArticuloId == id);
    }
    public async Task<bool> ActualizarArticulo(Articulos articulo)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Articulos.Update(articulo);
        return await _contexto
            .SaveChangesAsync() > 0;
    }
}
