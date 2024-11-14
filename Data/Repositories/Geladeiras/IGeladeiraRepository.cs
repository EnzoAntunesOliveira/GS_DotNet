using System.Collections.Generic;
using System.Threading.Tasks;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Geladeiras
{
    public interface IGeladeiraRepository
    {
        Task<IEnumerable<Geladeira>> GetAllAsync();
        Task<Geladeira> GetByIdAsync(int id);
        Task AddAsync(Geladeira geladeira);
        Task UpdateAsync(Geladeira geladeira);
        Task DeleteAsync(int id);
    }
}