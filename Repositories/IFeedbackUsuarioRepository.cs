using Sessions_app.Repositories;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public interface IFeedbackUsuarioRepository : IRepository<FeedbackUsuario>
    {
        Task<IEnumerable<FeedbackUsuario>> GetAllAsync();
        Task<FeedbackUsuario> GetByIdAsync(int id);
        Task AddAsync(FeedbackUsuario feedbackUsuario);
        Task UpdateAsync(FeedbackUsuario feedbackUsuario);
        Task DeleteAsync(int id);
    }
}
