using Microsoft.EntityFrameworkCore;
using Sessions_app.Repositories;
using SeuProjeto.Data;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public class ConteudoRepository : IConteudoRepository
    {
        private readonly OracleDbContext _context;

        public ConteudoRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Conteudo>> GetAllAsync()
        {
            return await _context.Conteudos.ToListAsync();
        }

        public async Task<Conteudo> GetByIdAsync(int id)
        {
            return await _context.Conteudos.FindAsync(id);
        }

        public async Task AddAsync(Conteudo conteudo)
        {
            _context.Conteudos.Add(conteudo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Conteudo conteudo)
        {
            _context.Conteudos.Update(conteudo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var conteudo = await _context.Conteudos.FindAsync(id);
            if (conteudo != null)
            {
                _context.Conteudos.Remove(conteudo);
                await _context.SaveChangesAsync();
            }
        }


    }
}
