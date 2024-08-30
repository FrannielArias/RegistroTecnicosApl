﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class TecnicoServices
{
    private readonly Contexto _contexto;

    public TecnicoServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int tecnicoId)
    {
        return await _contexto.Tecnicos
            .AnyAsync(t => t.TecnicoId == tecnicoId);
    }

    public async Task<bool> Insertar(Tecnicos tecnico)
    {
        _contexto.Tecnicos.Add(tecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Tecnicos tecnico)
    {
        _contexto.Update(tecnico);
        return await _contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if(!await Existe(tecnico.TecnicoId))
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
        return await _contexto .Tecnicos
            .AsNoTracking()
            .Where(e => e.TecnicoId == tecnico.TecnicoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Tecnicos?> Buscar(int TecnicoId)
    {
        return await _contexto.Tecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TecnicoId == TecnicoId);
    }

    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        return await _contexto.Tecnicos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}