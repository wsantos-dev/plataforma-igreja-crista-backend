namespace PlataformaRedencao.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public int UsuarioId { get; private set; }
        public string Token { get; private set; } = null!;
        public DateTimeOffset ExpiresAt { get; private set; }
        public bool Revoked { get; private set; }

        protected RefreshToken() { }

        public RefreshToken(int usuarioId, string token, DateTimeOffset expiresAt)
        {
            UsuarioId = usuarioId;
            Token = token;
            ExpiresAt = expiresAt;
            Revoked = false;
        }

        public void Revoke()
        {
            Revoked = true;
        }

        public bool IsValid()
            => !Revoked && DateTimeOffset.UtcNow <= ExpiresAt;
    }
}