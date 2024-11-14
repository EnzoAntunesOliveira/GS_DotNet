using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Eletrodomesticos
{
    public class EletrodomesticoRepository : IEletrodomesticoRepository
    {
        private readonly AppDbContext _context;

        public EletrodomesticoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Eletrodomestico>> GetAllAsync()
        {
            return await _context.Eletrodomesticos.ToListAsync();
        }

        public async Task<Eletrodomestico> GetByIdAsync(int id)
        {
            return await _context.Eletrodomesticos.FindAsync(id);
        }

        public async Task AddAsync(Eletrodomestico eletrodomestico)
        {
            await _context.Eletrodomesticos.AddAsync(eletrodomestico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Eletrodomestico eletrodomestico)
        {
            _context.Eletrodomesticos.Update(eletrodomestico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var eletrodomestico = await _context.Eletrodomesticos.FindAsync(id);
            if (eletrodomestico != null)
            {
                _context.Eletrodomesticos.Remove(eletrodomestico);
                await _context.SaveChangesAsync();
            }
        }
    }
}