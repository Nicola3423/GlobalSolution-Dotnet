using Microsoft.EntityFrameworkCore;
using Sessions_app.Repositories;
using SeuProjeto.Data;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public class InteracaoRepository : IInteracaoRepository
    {
        private readonly OracleDbContext _context;

        public InteracaoRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interacao>> GetAllAsync()
        {
            return await _context.Interacoes
                .Include(i => i.Usuario)
                .Include(i => i.Conteudo)
                .ToListAsync();
        }

        public async Task<Interacao> GetByIdAsync(int id)
        {
            return await _context.Interacoes
                .Include(i => i.Usuario)
                .Include(i => i.Conteudo)
                .FirstOrDefaultAsync(i => i.InteracaoId == id);
        }

        public async Task AddAsync(Interacao interacao)
        {
            _context.Interacoes.Add(interacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Interacao interacao)
        {
            _context.Interacoes.Update(interacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var interacao = await _context.Interacoes.FindAsync(id);
            if (interacao != null)
            {
                _context.Interacoes.Remove(interacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
