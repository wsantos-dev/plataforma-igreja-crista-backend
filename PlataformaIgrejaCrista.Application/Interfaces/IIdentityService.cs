using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces;

public interface IIdentityService
{
    Task<IReadOnlyCollection<UserDTO>> GetAllUserAsync();
    Task<(string accessToken, string refreshToken)> RegisterAsync(string userName, string password, string email);
    Task<(string accessToken, string refreshToken)> LoginAsync(string userName, string password);
}
