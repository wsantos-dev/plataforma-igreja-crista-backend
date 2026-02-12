using PlataformaRedencao.Application.Security;

namespace PlataformaRedencao.Infra.IoC.Security;

/// <summary>
/// Password hasher implementation using BCrypt.
/// </summary>
public class BCryptPasswordHasher : IPasswordHasher
{
    /// <inheritdoc />
    public string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    /// <inheritdoc />
    public bool Verify(string password, string passwordHash)
        => BCrypt.Net.BCrypt.Verify(password, passwordHash);
}
