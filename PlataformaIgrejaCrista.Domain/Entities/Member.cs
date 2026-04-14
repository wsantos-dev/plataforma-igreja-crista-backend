using PlataformaIgrejaCrista.Domain.ValueObjects;
using PlataformaIgrejaCrista.Domain.Enums;
using PlataformaIgrejaCrista.Domain.Validation;

namespace PlataformaIgrejaCrista.Domain.Entities
{
    /// <summary>
    /// Represents a church member.
    /// </summary>
    /// <remarks>
    /// This class holds all personal identification, contact, status and church history data.
    /// A member is a registered citizen (CPF), with name, contact, address, profession and other
    /// civil information, plus church-specific data such as admission date, admission type and status.
    /// </remarks>
    public sealed class Member : BaseEntity
    {
        private Member() { }

        /// <summary>
        /// ASP.NET Identity User
        /// </summary>
        public string? ApplicationUserId { get; set; }
        /// <summary>
        /// Person's CPF (Brazilian tax ID).
        /// </summary>
        public Cpf? Cpf { get; private set; }

        /// <summary>
        /// Person's full name.
        /// </summary>
        public PersonName? FullName { get; private set; }

        /// <summary>
        /// Person's birth date.
        /// </summary>
        public DateOnly BirthDate { get; private set; }

        /// <summary>
        /// Person's gender.
        /// </summary>
        public Gender? Gender { get; private set; }

        /// <summary>
        /// Person's contact information.
        /// </summary>
        public Contact? Contact { get; private set; }

        /// <summary>
        /// Person's marital status.
        /// </summary>
        public MaritalStatus MaritalStatus { get; private set; }

        /// <summary>
        /// Person's education level.
        /// </summary>
        public EducationLevel EducationLevel { get; private set; }

        /// <summary>
        /// Person's profession.
        /// </summary>
        public Profession? Profession { get; private set; }

        /// <summary>
        /// Profession identifier.
        /// </summary>
        public int ProfessionId { get; private set; }

        /// <summary>
        /// Address identifier.
        /// </summary>
        public int AddressId { get; private set; }

        /// <summary>
        /// Person's address.
        /// </summary>
        public Address? Address { get; private set; }

        /// <summary>
        /// Identifier of the church the member belongs to.
        /// </summary>
        /// <remarks>
        /// Foreign key to <see cref="Church"/>.
        /// </remarks>
        public int ChurchId { get; private set; }

        /// <summary>
        /// Church the member is linked to.
        /// </summary>
        public Church? Church { get; private set; }

        /// <summary>
        /// Member's church admission date.
        /// </summary>PlataformaRedencao.Application/DTOs/MemberCreationData.cs
        public DateOnly AdmissionDate { get; private set; }

        /// <summary>
        /// Member's admission type.
        /// </summary>
        public MemberAdmissionType AdmissionType { get; private set; }

        /// <summary>
        /// Current member status in the church.
        /// </summary>
        public MemberStatus Status { get; private set; }

        /// <summary>
        /// Member record creation timestamp.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Last update time of the member record.
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        private Member(
            Cpf cpf,
            PersonName name,
            Contact contact,
            DateOnly birthDate,
            Gender gender,
            Address address,
            Profession profession,
            Church church,
            DateOnly admissionDate,
            MemberAdmissionType admissionType)
        {
            ValidateDomain(
                cpf,
                name,
                contact,
                birthDate,
                gender,
                address,
                profession,
                church,
                admissionDate,
                admissionType
            );

            Cpf = cpf;
            FullName = name;
            Contact = contact;
            BirthDate = birthDate;
            Gender = gender;
            Address = address;
            Profession = profession;
            Church = church;
            AdmissionDate = admissionDate;
            AdmissionType = admissionType;


        }

        private void ValidateDomain(
            Cpf cpf,
            PersonName name,
            Contact contact,
            DateOnly birthDate,
            Gender gender,
            Address address,
            Profession profession,
            Church church,
            DateOnly admissionDate,
            MemberAdmissionType admissionType)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            DomainValidationException.When(cpf is null, "CPF é obrigatório.");
            DomainValidationException.When(name is null, "Nome é obrigatório.");
            DomainValidationException.When(contact is null, "Contato é obrigatório.");
            DomainValidationException.When(gender is null, "Gênero é obrigatório.");
            DomainValidationException.When(address is null, "Endereço é obrigatório.");
            DomainValidationException.When(profession is null, "Profissão é obrigatória.");
            DomainValidationException.When(church is null, "Igreja é obrigatória.");

            DomainValidationException.When(
                birthDate > today,
                "Data de nascimento não pode ser futura."
            );

            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
                age--;

            DomainValidationException.When(
                age < 12,
                "Idade mínima para admissão é 12 anos."
            );

            DomainValidationException.When(
                admissionDate < birthDate,
                "Data de admissão não pode ser anterior ao nascimento."
            );

            DomainValidationException.When(
                admissionDate > today,
                "Data de admissão não pode ser futura."
            );

            DomainValidationException.When(
                !Enum.IsDefined(typeof(MemberAdmissionType), admissionType),
                "Tipo de admissão inválido."
            );
        }

        /// <summary>
        /// Factory to create a new member.
        /// </summary>
        public static Member Create(
            MemberCreationData data,
            Address address,
            Profession profession,
            Church church)
        {
            var cpf = new Cpf(data.Cpf);
            var name = new PersonName(data.FirstName, data.LastName);
            var email = new EmailAddress(data.Email);

            var phone = string.IsNullOrWhiteSpace(data.Phone)
                ? null
                : new PhoneNumber(data.Phone);

            var contact = new Contact(email, phone);
            var gender = Gender.FromCode(data.GenderCode);

            return new Member(
                cpf,
                name,
                contact,
                data.BirthDate,
                gender,
                address,
                profession,
                church,
                data.AdmissionDate,
                data.AdmissionType
            );
        }


        /// <summary>
        /// Updates the member data.
        /// </summary>
        public void UpdateMember(
            DateOnly admissionDate,
            MemberAdmissionType admissionType,
            MemberStatus status)
        {
            AdmissionDate = admissionDate;
            AdmissionType = admissionType;
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
