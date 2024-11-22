using Sessions_app.Repositories;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public interface IInteracaoRepository 
    {
        Task<IEnumerable<Interacao>> GetAllAsync();
        Task<Interacao> GetByIdAsync(int id);
        Task AddAsync(Interacao interacao);
        Task UpdateAsync(Interacao interacao);
        Task DeleteAsync(int id);
    }
}
