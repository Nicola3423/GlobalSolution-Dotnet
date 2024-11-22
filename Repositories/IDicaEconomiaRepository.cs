using SeuProjeto.Models;

namespace Sessions_app.Repositories
{
    public interface IDicaEconomiaRepository
    {
        Task<IEnumerable<DicaEconomia>> GetAllAsync();
        Task<DicaEconomia> GetByIdAsync(int id);
        Task AddAsync(DicaEconomia dicaEconomia);
        Task UpdateAsync(DicaEconomia dicaEconomia);
        Task DeleteAsync(int id);
    }
}
