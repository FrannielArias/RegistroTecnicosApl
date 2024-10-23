using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class TecnicoServices(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int tecnicoId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Tecnicos
            .AnyAsync(t => t.TecnicoId == tecnicoId);
    }

    private async Task<bool> Insertar(Tecnicos tecnico)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Tecnicos.Add(tecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Tecnicos tecnico)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(tecnico);
        return await _contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(tecnico.TecnicoId))
        {
            return await Insertar(tecnico);
        }
        else
        {
            return await Modificar(tecnico);
        }
    }

    public async Task<bool> Eliminar(Tecnicos tecnico)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Tecnicos
            .AsNoTracking()
            .Where(t => t.TecnicoId == tecnico.TecnicoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteTecnico(int tecnicoId, string nombre)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Tecnicos
            .AnyAsync(t => t.TecnicoId != tecnicoId
            && t.Nombres.ToLower().Equals(nombre.ToLower()));
    }

    public async Task<Tecnicos?> Buscar(int tecnicoId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Tecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TecnicoId == tecnicoId);
    }

    public async Task<Tecnicos?> BuscarTipo(int tecnicoId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Tecnicos
            .Include(t => t.TipoTecnico)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TecnicoId == tecnicoId);
    }

    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Tecnicos
            .Include(t => t.TipoTecnico)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
