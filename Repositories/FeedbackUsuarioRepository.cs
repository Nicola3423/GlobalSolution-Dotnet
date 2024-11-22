using Microsoft.EntityFrameworkCore;
using Sessions_app.Repositories;
using SeuProjeto.Data;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public class FeedbackUsuarioRepository : IFeedbackUsuarioRepository
    {
        private readonly OracleDbContext _context;

        public FeedbackUsuarioRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeedbackUsuario>> GetAllAsync()
        {
            return await _context.FeedbackUsuarios
                .Include(f => f.Usuario)
                .Include(f => f.Conteudo)
                .ToListAsync();
        }

        public async Task<FeedbackUsuario> GetByIdAsync(int id)
        {
            return await _context.FeedbackUsuarios
                .Include(f => f.Usuario)
                .Include(f => f.Conteudo)
                .FirstOrDefaultAsync(f => f.FeedbackId == id);
        }

        public async Task AddAsync(FeedbackUsuario feedbackUsuario)
        {
            _context.FeedbackUsuarios.Add(feedbackUsuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FeedbackUsuario feedbackUsuario)
        {
            _context.FeedbackUsuarios.Update(feedbackUsuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var feedbackUsuario = await _context.FeedbackUsuarios.FindAsync(id);
            if (feedbackUsuario != null)
            {
                _context.FeedbackUsuarios.Remove(feedbackUsuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
