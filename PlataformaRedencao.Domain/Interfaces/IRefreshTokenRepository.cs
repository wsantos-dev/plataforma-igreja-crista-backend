using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    /// <summary>
    /// Repository for persistence operations on <see cref="RefreshToken"/> entities.
    /// </summary>
    public interface IRefreshTokenRepository
    {
        /// <summary>
        /// Adds a new refresh token.
        /// </summary>
        /// <param name="token">Refresh token to add.</param>
        Task AddAsync(RefreshToken token);

        /// <summary>
        /// Gets a refresh token by its value.
        /// </summary>
        /// <param name="token">Token value.</param>
        /// <returns>The refresh token.</returns>
        Task<RefreshToken> GetAsync(string token);

        /// <summary>
        /// Revokes a refresh token.
        /// </summary>
        /// <param name="token">Refresh token to revoke.</param>
        Task RevokeAsync(RefreshToken token);
    }
}