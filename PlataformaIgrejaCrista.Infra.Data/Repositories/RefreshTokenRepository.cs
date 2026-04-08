using Microsoft.EntityFrameworkCore;
using PlataformaIgrejaCrista.Domain.Entities;
using PlataformaIgrejaCrista.Domain.Interfaces;
using PlataformaIgrejaCrista.Infra.Data.Context;

namespace PlataformaIgrejaCrista.Infra.Data.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="IRefreshTokenRepository"/>.
    /// </summary>
    public sealed class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly PlataformaIgrejaCristaDbContext _context;

        public RefreshTokenRepository(PlataformaIgrejaCristaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
        }

        public async Task<RefreshToken?> GetByHashAsync(string tokenHash)
        {
            return await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.TokenHash == tokenHash);
        }

        public async Task<IReadOnlyCollection<RefreshToken>> GetActiveTokensByUserAsync(string userId)
        {
            return await _context.RefreshTokens
                .Where(x => x.UserId == userId && !x.Revoked)
                .ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
