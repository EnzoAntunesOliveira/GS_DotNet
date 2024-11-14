using System.Collections.Generic;
using System.Threading.Tasks;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Cafeteiras
{
    public interface ICafeteiraRepository
    {
        Task<IEnumerable<Cafeteira>> GetAllAsync();
        Task<Cafeteira> GetByIdAsync(int id);
        Task AddAsync(Cafeteira cafeteira);
        Task UpdateAsync(Cafeteira cafeteira);
        Task DeleteAsync(int id);
    }
}