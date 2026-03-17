namespace PlataformaRedencao.Application.DTOs;

public sealed record CreateMemberRequestDTO(
    string? Cpf,
    string? FirstName,
    string? LastName,
    string? Email,
    string? Phone,
    DateOnly BirthDate,
    char Gender,
    int ProfessionId,
    int ChurchId,
    DateOnly AdmissionDate,
    int AdmissionType,
    AddressRequestDTO? Address
);

