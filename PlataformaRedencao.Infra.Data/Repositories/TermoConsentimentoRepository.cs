using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class TermoConsentimentoRepository : ITermoConsentimentoRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        public TermoConsentimentoRepository(PlataformaRedencaoDbContext context)
            => _context = context;

        public async Task<TermoConsentimento?> GetByIdAsync(int? id)
            => await _context.TermoConsentimentos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<IReadOnlyCollection<TermoConsentimento?>> GetAllAsync()
            => await _context.TermoConsentimentos
            .AsNoTracking()
            .ToListAsync();

        public async Task<TermoConsentimento> AddAsync(TermoConsentimento entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<TermoConsentimento> UpdateAsync(TermoConsentimento entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<TermoConsentimento> DeleteAsync(TermoConsentimento entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }
    }
}