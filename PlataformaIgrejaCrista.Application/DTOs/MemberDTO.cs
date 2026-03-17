using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.ValueObjects;

namespace PlataformaRedencao.Application.DTOs;

public sealed record MemberDTO(
    int Id,
    string Cpf,
    string FirstName,
    string LastName,
    DateOnly BirthDate,
    Gender Gender,
    ContactDTO Contact,
    MaritalStatus MaritalStatus,
    EducationLevel EducationLevel,
    int ProfessionId,
    ProfessionDTO? Profession,
    int AddressId,
    AddressDTO? Address,
    int ChurchId,
    ChurchDTO? Church,
    DateOnly AdmissionDate,
    MemberAdmissionType AdmissionType,
    MemberStatus Status
)
{
    public string FullName => $"{FirstName} {LastName}";
}