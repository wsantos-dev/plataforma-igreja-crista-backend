namespace PlataformaRedencao.Application.Security
{
    /// <summary>
    /// Generates cryptographically secure refresh token values.
    /// </summary>
    public interface IRefreshTokenGenerator
    {
        /// <summary>
        /// Generates a new refresh token value.
        /// </summary>
        /// <returns>Token string.</returns>
        string Generate();
    }
}