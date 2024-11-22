using Sessions_app.Repositories;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public interface IConteudoRepository 
    {
        Task<IEnumerable<Conteudo>> GetAllAsync();
        Task<Conteudo> GetByIdAsync(int id);
        Task AddAsync(Conteudo conteudo);
        Task UpdateAsync(Conteudo conteudo);
        Task DeleteAsync(int id);
    }
}
