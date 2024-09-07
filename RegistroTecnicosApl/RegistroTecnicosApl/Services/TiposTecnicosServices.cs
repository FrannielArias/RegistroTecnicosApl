using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class TiposTecnicosServices
{
    private readonly Contexto _contexto;

    public TiposTecnicosServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    private async Task<bool> Existe(int tiposTecnicoId)
    {
        return await _contexto.TiposTecnicos
            .AnyAsync(t => t.TipoTecnicoId == tiposTecnicoId);
    }

    private async Task <bool> Insertar(TiposTecnicos tiposTecnicos)
    {
        _contexto.TiposTecnicos.Add(tiposTecnicos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(TiposTecnicos tiposTecnicos)
    {
        _contexto.Update(tiposTecnicos);
        return await _contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(TiposTecnicos tiposTecnico)
    {
        if(!await Existe(tiposTecnico.TipoTecnicoId))
        {
            return await Insertar(tiposTecnico);
        }               
        else
        {
            return await Modificar(tiposTecnico);
        }       
    }

    public async Task<bool> Eliminar(TiposTecnicos tiposTecnicos)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .Where(t => t.TipoTecnicoId == tiposTecnicos.TipoTecnicoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> ExisteTiposTecnico(int tiposTecnicosId, string descripcion)
    {
        return await _contexto.TiposTecnicos
            .AnyAsync(t => t.TipoTecnicoId != tiposTecnicosId 
            && t.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }

    public async Task<TiposTecnicos?> Buscar(int tipoTecnicoId)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoTecnicoId == tipoTecnicoId);
    }

    public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
    {
        return await _contexto.TiposTecnicos 
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

}
