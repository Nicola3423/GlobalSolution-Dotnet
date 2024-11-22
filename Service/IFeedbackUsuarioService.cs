using Sessions_app.DTOs;

namespace Sessions_app.Service
{
    public interface IFeedbackUsuarioService
    {
        Task<IEnumerable<FeedbackUsuarioDTO>> GetAllAsync();
        Task<FeedbackUsuarioDTO> GetByIdAsync(int id);
        Task AddAsync(FeedbackUsuarioDTO feedbackUsuarioDto);
        Task UpdateAsync(int id, FeedbackUsuarioDTO feedbackUsuarioDto);
        Task DeleteAsync(int id);
    }
}
