namespace PlataformaRedencao.Application.DTOs;

public record UserDTO(
    string UserName,
    string Password,
    string Email
);