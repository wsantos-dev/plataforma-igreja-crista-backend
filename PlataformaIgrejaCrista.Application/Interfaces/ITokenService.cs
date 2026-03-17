using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(ApplicationUser user);
}
