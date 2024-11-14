using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Ventiladores
{
    public class VentiladorRepository : IVentiladorRepository
    {
        private readonly AppDbContext _context;

        public VentiladorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ventilador>> GetAllAsync()
        {
            return await _context.Ventiladores.ToListAsync();
        }

        public async Task<Ventilador> GetByIdAsync(int id)
        {
            return await _context.Ventiladores.FindAsync(id);
        }

        public async Task AddAsync(Ventilador ventilador)
        {
            await _context.Ventiladores.AddAsync(ventilador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ventilador ventilador)
        {
            _context.Ventiladores.Update(ventilador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ventilador = await _context.Ventiladores.FindAsync(id);
            if (ventilador != null)
            {
                _context.Ventiladores.Remove(ventilador);
                await _context.SaveChangesAsync();
            }
        }
    }
}