using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Microondas
{
    public class MicroondasRepository : IMicroondasRepository
    {
        private readonly AppDbContext _context;

        public MicroondasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Microondas>> GetAllAsync()
        {
            return await _context.Microondas.ToListAsync();
        }

        public async Task<Domain.Entities.Microondas> GetByIdAsync(int id)
        {
            return await _context.Microondas.FindAsync(id);
        }

        public async Task AddAsync(Domain.Entities.Microondas microondas)
        {
            await _context.Microondas.AddAsync(microondas);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Microondas microondas)
        {
            _context.Microondas.Update(microondas);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var microondas = await _context.Microondas.FindAsync(id);
            if (microondas != null)
            {
                _context.Microondas.Remove(microondas);
                await _context.SaveChangesAsync();
            }
        }
    }
}