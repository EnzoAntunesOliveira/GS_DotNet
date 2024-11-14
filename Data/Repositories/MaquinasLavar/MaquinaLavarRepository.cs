using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.MaquinasLavar
{
    public class MaquinaLavarRepository : IMaquinaLavarRepository
    {
        private readonly AppDbContext _context;

        public MaquinaLavarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaquinaLavar>> GetAllAsync()
        {
            return await _context.Lavadoras.ToListAsync();
        }

        public async Task<MaquinaLavar> GetByIdAsync(int id)
        {
            return await _context.Lavadoras.FindAsync(id);
        }

        public async Task AddAsync(MaquinaLavar maquinaLavar)
        {
            await _context.Lavadoras.AddAsync(maquinaLavar);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MaquinaLavar maquinaLavar)
        {
            _context.Lavadoras.Update(maquinaLavar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var maquinaLavar = await _context.Lavadoras.FindAsync(id);
            if (maquinaLavar != null)
            {
                _context.Lavadoras.Remove(maquinaLavar);
                await _context.SaveChangesAsync();
            }
        }
    }
}