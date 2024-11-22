using Sessions_app.DTOs;

namespace Sessions_app.Service
{
    public interface IPontuacaoQuizService
    {
        Task<IEnumerable<PontuacaoQuizDTO>> GetAllAsync();
        Task<PontuacaoQuizDTO> GetByIdAsync(int id);
        Task AddAsync(PontuacaoQuizDTO pontuacaoQuizDto);
        Task UpdateAsync(int id, PontuacaoQuizDTO pontuacaoQuizDto);
        Task DeleteAsync(int id);
    }
}
