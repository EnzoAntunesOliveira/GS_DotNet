using System.Collections.Generic;
using System.Threading.Tasks;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Ventiladores
{
    public interface IVentiladorRepository
    {
        Task<IEnumerable<Ventilador>> GetAllAsync();
        Task<Ventilador> GetByIdAsync(int id);
        Task AddAsync(Ventilador ventilador);
        Task UpdateAsync(Ventilador ventilador);
        Task DeleteAsync(int id);
    }
}