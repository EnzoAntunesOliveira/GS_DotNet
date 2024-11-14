using System.Collections.Generic;
using System.Threading.Tasks;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Microondas
{
    public interface IMicroondasRepository
    {
        Task<IEnumerable<Domain.Entities.Microondas>> GetAllAsync();
        Task<Domain.Entities.Microondas> GetByIdAsync(int id);
        Task AddAsync(Domain.Entities.Microondas microondas);
        Task UpdateAsync(Domain.Entities.Microondas microondas);
        Task DeleteAsync(int id);
    }
}