﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using SQLitePCL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services;

public class ClientesServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Clientes cliente)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        if (!await Existe(cliente.ClienteId))
        {
            return await Insertar(cliente);
        }
        else
        {
            return await Modificar(cliente);
        }
    }
    private async Task<bool> Existe(int clienteId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Clientes
            .AnyAsync(c => c.ClienteId == clienteId);
    }
    private async Task<bool> Insertar(Clientes cliente)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Clientes.Add(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Clientes cliente)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        _contexto.Update(cliente);
        return await _contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Eliminar(Clientes cliente)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Clientes
            .AsNoTracking()
            .Where(c => c.ClienteId == cliente.ClienteId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Clientes?> Buscar(int clienteId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
    }

    public async Task<bool> ExisteCliente(int clienteId, string nombre, string whatsApp)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Clientes
            .AnyAsync(c => c.ClienteId != clienteId
            && (c.Nombres.ToLower().Equals(nombre.ToLower())
            || c.WhatsApp.ToLower().Equals(whatsApp.ToLower())));
    }



    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Clientes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
