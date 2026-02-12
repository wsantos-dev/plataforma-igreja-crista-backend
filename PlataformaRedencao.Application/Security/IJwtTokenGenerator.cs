using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Application.Security
{
    /// <summary>
    /// Generates JWT access tokens for authenticated users.
    /// </summary>
    public interface IJwtTokenGenerator
    {
        /// <summary>
        /// Generates a JWT access token for the given user.
        /// </summary>
        /// <param name="user">User entity.</param>
        /// <returns>Encoded JWT string.</returns>
        string GenerateToken(User user);
    }
}