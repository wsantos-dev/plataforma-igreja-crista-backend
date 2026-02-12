namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Represents a refresh token used to obtain new access tokens without re-authentication.
    /// </summary>
    public class RefreshToken : BaseEntity
    {
        /// <summary>
        /// User id that owns this token.
        /// </summary>
        public int UsuarioId { get; private set; }

        /// <summary>
        /// Token value.
        /// </summary>
        public string Token { get; private set; } = null!;

        /// <summary>
        /// Expiration date and time.
        /// </summary>
        public DateTimeOffset ExpiresAt { get; private set; }

        /// <summary>
        /// Whether the token has been revoked.
        /// </summary>
        public bool Revoked { get; private set; }

        /// <summary>
        /// Parameterless constructor for ORM.
        /// </summary>
        protected RefreshToken() { }

        /// <summary>
        /// Creates a new refresh token.
        /// </summary>
        /// <param name="usuarioId">User id.</param>
        /// <param name="token">Token value.</param>
        /// <param name="expiresAt">Expiration date and time.</param>
        public RefreshToken(int usuarioId, string token, DateTimeOffset expiresAt)
        {
            UsuarioId = usuarioId;
            Token = token;
            ExpiresAt = expiresAt;
            Revoked = false;
        }

        /// <summary>
        /// Revokes this token so it can no longer be used.
        /// </summary>
        public void Revoke()
        {
            Revoked = true;
        }

        /// <summary>
        /// Indicates whether this token is still valid (not revoked and not expired).
        /// </summary>
        /// <returns><c>true</c> if valid; otherwise <c>false</c>.</returns>
        public bool IsValid()
            => !Revoked && DateTimeOffset.UtcNow <= ExpiresAt;
    }
}