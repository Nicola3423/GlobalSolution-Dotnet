using Sessions_app.Repositories;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public interface IUsuarioRepository 
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}


