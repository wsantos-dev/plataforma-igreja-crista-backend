using PlataformaIgrejaCrista.Domain.Interfaces;

namespace PlataformaIgrejaCrista.Domain.Entities
{
    /// <summary>
    /// Represents a refresh token used to obtain new access tokens without re-authentication.
    /// </summary>
    public sealed class RefreshToken
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// SHA256 hash of the refresh token.
        /// </summary>
        public string TokenHash { get; private set; } = null!;

        public string UserId { get; private set; } = null!;

        public DateTime ExpiresAt { get; private set; }

        public bool Revoked { get; private set; }

        private RefreshToken() { }

        private RefreshToken(
            string userId,
            string tokenHash,
            DateTime expiresAt)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            TokenHash = tokenHash;
            ExpiresAt = expiresAt;
            Revoked = false;
        }

        public static RefreshToken Create(
            string userId,
            string rawToken,
            IHashingService hashingService,
            DateTime expiresAt)
        {
            var hash = hashingService.ComputeSha256(rawToken);

            return new RefreshToken(userId, hash, expiresAt);
        }

        public bool Matches(string rawToken, IHashingService hashingService)
        {
            var hash = hashingService.ComputeSha256(rawToken);
            return TokenHash == hash;
        }

        public void Revoke()
        {
            Revoked = true;
        }

        public bool IsValid()
        {
            return !Revoked && DateTime.UtcNow <= ExpiresAt;
        }
    }
}
