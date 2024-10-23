using Microsoft.EntityFrameworkCore;
using RegistroTecnicosApl.DAL;
using RegistroTecnicosApl.Models;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroTecnicosApl.Services
{
    public class DetalleService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(TrabajosDetalle trabajoDetalle)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            if (!await Existe(trabajoDetalle.DetalleId))
            {
                return await Insertar(trabajoDetalle);
            }
            else
            {
                return await Modificar(trabajoDetalle);
            }
        }
        private async Task<bool> Existe(int detalleId)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.TrabajoDetalle
                .AnyAsync(d => d.DetalleId == detalleId);
        }
        private async Task<bool> Insertar(TrabajosDetalle trabajoDetalle)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            _contexto.Add(trabajoDetalle);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(TrabajosDetalle trabajoDetalle)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            _contexto.Update(trabajoDetalle);
            return await _contexto
                .SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(TrabajosDetalle trabajoDetalle)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.TrabajoDetalle
                .AsNoTracking()
                .Where(d => d.DetalleId == trabajoDetalle.DetalleId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<TrabajosDetalle?> Buscar(int detalleId)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.TrabajoDetalle
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.DetalleId == detalleId);

        }

        public async Task<List<TrabajosDetalle>> Listar(Expression<Func<TrabajosDetalle, bool>> criterio)
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            return await _contexto.TrabajoDetalle
                .Include(a => a.ArticuloId)
                .Include(b => b.Trabajos)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
