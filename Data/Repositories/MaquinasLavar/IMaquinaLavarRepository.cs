using System.Collections.Generic;
using System.Threading.Tasks;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.MaquinasLavar
{
    public interface IMaquinaLavarRepository
    {
        Task<IEnumerable<MaquinaLavar>> GetAllAsync();
        Task<MaquinaLavar> GetByIdAsync(int id);
        Task AddAsync(MaquinaLavar maquinaLavar);
        Task UpdateAsync(MaquinaLavar maquinaLavar);
        Task DeleteAsync(int id);
    }
}