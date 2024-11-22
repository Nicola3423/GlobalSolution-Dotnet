using Sessions_app.DTOs;
using SeuProjeto.Models;

namespace Sessions_app.Service
{
    public interface IDicaEconomiaService
    {
        Task<IEnumerable<DicaEconomiaDTO>> GetAllAsync();
        Task<DicaEconomiaDTO> GetByIdAsync(int id);
        Task AddAsync(DicaEconomiaDTO dicaEconomiaDto);
        Task UpdateAsync(int id, DicaEconomiaDTO dicaEconomiaDto);
        Task DeleteAsync(int id);
    }
}
