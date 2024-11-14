using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Cafeteiras
{
    public class CafeteiraRepository : ICafeteiraRepository
    {
        private readonly AppDbContext _context;

        public CafeteiraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cafeteira>> GetAllAsync()
        {
            return await _context.Cafeteiras.ToListAsync();
        }

        public async Task<Cafeteira> GetByIdAsync(int id)
        {
            return await _context.Cafeteiras.FindAsync(id);
        }

        public async Task AddAsync(Cafeteira cafeteira)
        {
            await _context.Cafeteiras.AddAsync(cafeteira);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cafeteira cafeteira)
        {
            _context.Cafeteiras.Update(cafeteira);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cafeteira = await _context.Cafeteiras.FindAsync(id);
            if (cafeteira != null)
            {
                _context.Cafeteiras.Remove(cafeteira);
                await _context.SaveChangesAsync();
            }
        }
    }
}