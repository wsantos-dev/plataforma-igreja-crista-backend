using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        public RefreshTokenRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken token)
        {
            _context.RefreshTokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetAsync(string token)
        {
            return await _context.RefreshTokens
                .FirstAsync(r => r.Token == token);
        }

        public async Task RevokeAsync(RefreshToken token)
        {
            token.Revoke();
            await _context.SaveChangesAsync();
        }
    }
}