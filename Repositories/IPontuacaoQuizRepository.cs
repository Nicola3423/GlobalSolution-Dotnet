using Sessions_app.Repositories;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public interface IPontuacaoQuizRepository
    {
        Task<IEnumerable<PontuacaoQuiz>> GetAllAsync();
        Task<PontuacaoQuiz> GetByIdAsync(int id);
        Task AddAsync(PontuacaoQuiz pontuacaoQuiz);
        Task UpdateAsync(PontuacaoQuiz pontuacaoQuiz);
        Task DeleteAsync(int id);
    }
}
