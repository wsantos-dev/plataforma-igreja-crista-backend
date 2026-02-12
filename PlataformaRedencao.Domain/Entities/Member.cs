using PlataformaRedencao.Domain.ValueObjects;
using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
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
        /// </summary>
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
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Last update timestamp of the member record.
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; private set; }

        /// <summary>
        /// Factory to create a new member.
        /// </summary>
        public static Member Create(
            Cpf cpf,
            PersonName fullName,
            Contact contact,
            DateOnly birthDate,
            Gender gender,
            Address address,
            Profession profession,
            Church church,
            DateOnly admissionDate,
            MemberAdmissionType admissionType)
        {
            var member = new Member
            {
                Cpf = cpf,
                FullName = fullName,
                Contact = contact,
                BirthDate = birthDate,
                Gender = gender,
                Address = address,
                AddressId = address.Id,
                Profession = profession,
                ProfessionId = profession.Id,
                Church = church,
                ChurchId = church.Id,
                AdmissionDate = admissionDate,
                AdmissionType = admissionType,
                Status = MemberStatus.Active,
                CreatedAt = DateTimeOffset.UtcNow
            };

            return member;
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
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
