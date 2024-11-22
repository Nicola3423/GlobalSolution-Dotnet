using Sessions_app.DTOs;

namespace Sessions_app.Service
{
    public interface IInteracaoService
    {
        Task<IEnumerable<InteracaoDTO>> GetAllAsync();
        Task<InteracaoDTO> GetByIdAsync(int id);
        Task AddAsync(InteracaoDTO interacaoDto);
        Task UpdateAsync(int id, InteracaoDTO interacaoDto);
        Task DeleteAsync(int id);
    }
}
