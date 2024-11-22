using Sessions_app.DTOs;
using SeuProjeto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeuProjeto.Services
{
    public interface IConteudoService
    {
        Task<IEnumerable<ConteudoDTO>> GetAllAsync();
        Task<ConteudoDTO> GetByIdAsync(int id);
        Task AddAsync(ConteudoDTO conteudoDto);
        Task UpdateAsync(int id, ConteudoDTO conteudoDto);
        Task DeleteAsync(int id);
    }
}
