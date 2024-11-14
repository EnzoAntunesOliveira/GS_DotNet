using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Geladeiras
{
    public class GeladeiraRepository : IGeladeiraRepository
    {
        private readonly AppDbContext _context;

        public GeladeiraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Geladeira>> GetAllAsync()
        {
            return await _context.Geladeiras.ToListAsync();
        }

        public async Task<Geladeira> GetByIdAsync(int id)
        {
            return await _context.Geladeiras.FindAsync(id);
        }

        public async Task AddAsync(Geladeira geladeira)
        {
            await _context.Geladeiras.AddAsync(geladeira);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Geladeira geladeira)
        {
            _context.Geladeiras.Update(geladeira);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var geladeira = await _context.Geladeiras.FindAsync(id);
            if (geladeira != null)
            {
                _context.Geladeiras.Remove(geladeira);
                await _context.SaveChangesAsync();
            }
        }
    }
}