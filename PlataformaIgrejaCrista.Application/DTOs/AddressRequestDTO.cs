namespace PlataformaRedencao.Application.DTOs;

public sealed record AddressRequestDTO(
    string? Street,
    string? Complement,
    string? Number,
    string? City,
    string? State,
    string? Country,
    string? PostalCode
);