using Microsoft.EntityFrameworkCore;
using Sessions_app.Repositories;
using SeuProjeto.Data;
using SeuProjeto.Models;

namespace SeuProjeto.Repositories
{
    public class DicaEconomiaRepository : IDicaEconomiaRepository
    {
        private readonly OracleDbContext _context;

        public DicaEconomiaRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DicaEconomia>> GetAllAsync()
        {
            return await _context.DicasEconomia.ToListAsync();
        }

        public async Task<DicaEconomia> GetByIdAsync(int id)
        {
            return await _context.DicasEconomia.FindAsync(id);
        }

        public async Task AddAsync(DicaEconomia dicaEconomia)
        {
            _context.DicasEconomia.Add(dicaEconomia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DicaEconomia dicaEconomia)
        {
            _context.DicasEconomia.Update(dicaEconomia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dicaEconomia = await _context.DicasEconomia.FindAsync(id);
            if (dicaEconomia != null)
            {
                _context.DicasEconomia.Remove(dicaEconomia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
