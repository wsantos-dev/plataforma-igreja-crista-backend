namespace PlataformaRedencao.Application.DTOs;

public sealed record ChurchDTO(
    int Id,
    string OfficialName,
    string TradeName,
    string? Denomination,
    string LeadPastor,
    DateOnly FoundationDate,
    string Cnpj,
    string Email,
    string Website,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt,
    int? AddressId,
    AddressDTO? Address
);