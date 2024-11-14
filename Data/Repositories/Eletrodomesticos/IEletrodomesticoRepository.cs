using System.Collections.Generic;
using System.Threading.Tasks;
using Gs_DotNet.Domain.Entities;

namespace Gs_DotNet.Data.Repositories.Eletrodomesticos
{
    public interface IEletrodomesticoRepository
    {
        Task<IEnumerable<Eletrodomestico>> GetAllAsync();
        Task<Eletrodomestico> GetByIdAsync(int id);
        Task AddAsync(Eletrodomestico eletrodomestico);
        Task UpdateAsync(Eletrodomestico eletrodomestico);
        Task DeleteAsync(int id);
    }
}