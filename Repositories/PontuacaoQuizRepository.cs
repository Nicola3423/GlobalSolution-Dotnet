using Microsoft.EntityFrameworkCore;
using Sessions_app.Repositories;
using SeuProjeto.Data;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public class PontuacaoQuizRepository : IPontuacaoQuizRepository
    {
        private readonly OracleDbContext _context;

        public PontuacaoQuizRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PontuacaoQuiz>> GetAllAsync()
        {
            return await _context.PontuacoesQuiz
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public async Task<PontuacaoQuiz> GetByIdAsync(int id)
        {
            return await _context.PontuacoesQuiz
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.PontuacaoId == id);
        }

        public async Task AddAsync(PontuacaoQuiz pontuacaoQuiz)
        {
            _context.PontuacoesQuiz.Add(pontuacaoQuiz);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PontuacaoQuiz pontuacaoQuiz)
        {
            _context.PontuacoesQuiz.Update(pontuacaoQuiz);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pontuacaoQuiz = await _context.PontuacoesQuiz.FindAsync(id);
            if (pontuacaoQuiz != null)
            {
                _context.PontuacoesQuiz.Remove(pontuacaoQuiz);
                await _context.SaveChangesAsync();
            }
        }
    }
}
