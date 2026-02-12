namespace PlataformaRedencao.Application.Security;

/// <summary>
/// Hashes and verifies passwords using a secure one-way algorithm.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Hashes a plain-text password.
    /// </summary>
    /// <param name="password">Plain-text password.</param>
    /// <returns>Hashed password string.</returns>
    string Hash(string password);

    /// <summary>
    /// Verifies a plain-text password against a stored hash.
    /// </summary>
    /// <param name="password">Plain-text password.</param>
    /// <param name="passwordHash">Stored hash to verify against.</param>
    /// <returns><c>true</c> if the password matches; otherwise <c>false</c>.</returns>
    bool Verify(string password, string passwordHash);
}
