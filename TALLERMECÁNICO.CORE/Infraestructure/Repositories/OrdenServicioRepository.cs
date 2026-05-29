using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALLERMECÁNICO.CORE.Core.Entities;
using TALLERMECÁNICO.CORE.Core.Interfaces;


namespace TALLERMECÁNICO.CORE.Infrastructure.Repositories
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly TallerMecanicoDbContext _context;

        public OrdenServicioRepository(TallerMecanicoDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<IEnumerable<OrdenServicio>> GetOrdenesServicio()
        {
            return await _context.OrdenServicio.ToListAsync();
        }

        // GET BY ID
        public async Task<OrdenServicio> GetOrdenServicioById(int id)
        {
            return await _context
                .OrdenServicio
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();
        }

        // CREATE
        public async Task CreateOrdenServicio(OrdenServicio ordenServicio)
        {
            _context.OrdenServicio.Add(ordenServicio);
            await _context.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateOrdenServicio(OrdenServicio ordenServicio)
        {
            var existingOrden = await _context
                .OrdenServicio
                .Where(o => o.Id == ordenServicio.Id)
                .FirstOrDefaultAsync();

            if (existingOrden != null)
            {
                existingOrden.FechaIngreso = ordenServicio.FechaIngreso;
                existingOrden.DescripcionProblema = ordenServicio.DescripcionProblema;
                existingOrden.CostoEstimado = ordenServicio.CostoEstimado;
                existingOrden.Estado = ordenServicio.Estado;
                existingOrden.VehiculoId = ordenServicio.VehiculoId;
                existingOrden.TipoServicioId = ordenServicio.TipoServicioId;

                await _context.SaveChangesAsync();
            }
        }

        // DELETE
        public async Task DeleteOrdenServicio(int id)
        {
            var existingOrden = await _context
                .OrdenServicio
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (existingOrden != null)
            {
                _context.OrdenServicio.Remove(existingOrden);

                await _context.SaveChangesAsync();
            }
        }
    }
}