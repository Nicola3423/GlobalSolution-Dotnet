using Sessions_app.DTOs;

namespace Sessions_app.Service
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO> GetByIdAsync(int id);
        Task AddAsync(UsuarioDTO usuarioDto);
        Task UpdateAsync(int id, UsuarioDTO usuarioDto);
        Task DeleteAsync(int id);
    }
}
