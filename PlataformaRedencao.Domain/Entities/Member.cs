using PlataformaRedencao.Domain.ValueObjects;
using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa um membro da igreja.
    /// </summary>
    /// <remarks>
    /// Esta classe concentra todos os dados de identificação pessoal,
    /// contato, situação e histórico eclesiástico.
    /// Um membro é um cidadão registrado (CPF), com nome, contato, endereço,
    /// profissão e demais informações civis, além de dados específicos
    /// relacionados à igreja, como data de admissão, tipo de admissão e situação.
    /// </remarks>
    public sealed class Member : BaseEntity
    {
        private Member() { }

        /// <summary>
        /// CPF da pessoa.
        /// </summary>
        public Cpf? Cpf { get; private set; }

        /// <summary>
        /// Nome completo da pessoa.
        /// </summary>
        public PersonName? FullName { get; private set; }

        /// <summary>
        /// Data de nascimento da pessoa.
        /// </summary>
        public DateOnly BirthDate { get; private set; }

        /// <summary>
        /// Sexo da pessoa.
        /// </summary>
        public Gender? Gender { get; private set; }

        /// <summary>
        /// Informações de contato da pessoa.
        /// </summary>
        public Contact? Contact { get; private set; }

        /// <summary>
        /// Estado civil da pessoa.
        /// </summary>
        public MaritalStatus MaritalStatus { get; private set; }

        /// <summary>
        /// Grau de escolaridade da pessoa.
        /// </summary>
        public EducationLevel EducationLevel { get; private set; }

        /// <summary>
        /// Profissão exercida pela pessoa.
        /// </summary>
        public Profession? Profession { get; private set; }

        /// <summary>
        /// Identificador da profissão.
        /// </summary>
        public int ProfessionId { get; private set; }

        /// <summary>
        /// Identificador do endereço.
        /// </summary>
        public int AddressId { get; private set; }

        /// <summary>
        /// Endereço da pessoa.
        /// </summary>
        public Address? Address { get; private set; }

        /// <summary>
        /// Identificador da igreja à qual o membro pertence.
        /// </summary>
        /// <remarks>
        /// Chave estrangeira para a entidade <see cref="Church"/>.
        /// </remarks>
        public int ChurchId { get; private set; }

        /// <summary>
        /// Igreja à qual o membro está vinculado.
        /// </summary>
        public Church? Church { get; private set; }

        /// <summary>
        /// Data de admissão do membro na igreja.
        /// </summary>
        public DateOnly AdmissionDate { get; private set; }

        /// <summary>
        /// Tipo de admissão do membro.
        /// </summary>
        public MemberAdmissionType AdmissionType { get; private set; }

        /// <summary>
        /// Situação atual do membro na igreja.
        /// </summary>
        public MemberStatus Status { get; private set; }

        /// <summary>
        /// Data de criação do cadastro do Membro.
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Data da última atualização do cadastro do Membro.
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; private set; }

        /// <summary>
        /// Fábrica para criar um novo membro.
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
        /// Atualiza os dados do membro.
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
