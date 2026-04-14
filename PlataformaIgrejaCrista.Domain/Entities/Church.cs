using System.Text.RegularExpressions;
using PlataformaIgrejaCrista.Domain.Validation;
using PlataformaIgrejaCrista.Domain.ValueObjects;

namespace PlataformaIgrejaCrista.Domain.Entities
{
    /// <summary>
    /// Aggregate root representing a church within the platform domain.
    /// </summary>
    /// <remarks>
    /// <see cref="Church"/> holds the official church data, including civil information,
    /// contact, leadership and main address.
    /// </remarks>
    public sealed class Church : BaseEntity
    {
        /// <summary>
        /// Official name of the church.
        /// </summary>
        public string OfficialName { get; private set; }

        /// <summary>
        /// Trade name or short name used publicly.
        /// </summary>
        public string TradeName { get; private set; }

        /// <summary>
        /// Denomination the church belongs to.
        /// </summary>
        public string? Denomination { get; private set; }

        /// <summary>
        /// Lead pastor or main leader of the church.
        /// </summary>
        public string LeadPastor { get; private set; }

        /// <summary>
        /// Church foundation date.
        /// </summary>
        public DateOnly FoundationDate { get; private set; }

        /// <summary>
        /// Legal registration number of the church (CNPJ).
        /// </summary>
        public string Cnpj { get; private set; }

        /// <summary>
        /// Institutional email of the church.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Official website of the church.
        /// </summary>
        public string Website { get; private set; }

        /// <summary>
        /// Church record creation timestamp in the system.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Last update time of the church record.
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Foreign key to the church's main address.
        /// </summary>
        /// <remarks>
        /// References the main address stored in <see cref="Address"/>.
        /// </remarks>
        public int? AddressId { get; private set; }

        /// <summary>
        /// Navigation reference to the address.
        /// </summary>
        public Address? Address { get; private set; }

        /// <summary>
        /// Creates a new church instance with the essential data.
        /// </summary>
        /// <param name="officialName">Official name of the church.</param>
        /// <param name="tradeName">Trade name or short name of the church.</param>
        /// <param name="denomination">Religious denomination of the church.</param>
        /// <param name="leadPastor">Lead pastor or main leader.</param>
        /// <param name="foundationDate">Church foundation date.</param>
        /// <param name="cnpj">Church CNPJ.</param>
        /// <param name="email">Institutional email.</param>
        /// <param name="website">Official website of the church.</param>
        public Church(
            string officialName,
            string tradeName,
            string denomination,
            string leadPastor,
            DateOnly foundationDate,
            string cnpj,
            string email,
            string website)
        {

            ValidateDomain(
                officialName,
                tradeName,
                denomination,
                leadPastor,
                foundationDate,
                cnpj,
                email,
                website
            );

            OfficialName = officialName;
            TradeName = tradeName;
            Denomination = denomination;
            LeadPastor = leadPastor;
            FoundationDate = foundationDate;
            Cnpj = new Cnpj(cnpj);
            Email = email;
            Website = website;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Changes the church's main address by setting the FK to the given address.
        /// </summary>
        /// <param name="address">Existing address to be set as the main one.</param>
        /// <remarks>
        /// Updates the navigation reference and <see cref="AddressId"/>.
        /// </remarks>
        public void ChangeAddress(Address address)
        {
            AddressId = address.Id;
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }

        // Método privado ou público dependendo se você usa ele externamente (ex: em um Update)
        public void ValidateDomain(
            string officialName,
            string tradeName,
            string denomination,
            string leadPastor,
            DateOnly foundationDate,
            string cnpj,
            string email,
            string website)
        {

            DomainValidationException.When(string.IsNullOrWhiteSpace(officialName), "A Razão Social é obrigatória.");
            DomainValidationException.When(string.IsNullOrWhiteSpace(tradeName), "O Nome Fantasia é obrigatório.");
            DomainValidationException.When(string.IsNullOrWhiteSpace(leadPastor), "O Pastor Responsável é obrigatório.");
            DomainValidationException.When(string.IsNullOrWhiteSpace(email), "O E-mail é obrigatório.");

            // --- 2. Validações de Tamanho (Length) ---
            DomainValidationException.When(officialName.Length < 3, "A Razão Social deve ter no mínimo 3 caracteres.");
            DomainValidationException.When(officialName.Length > 200, "A Razão Social excede o limite máximo de caracteres.");

            DomainValidationException.When(tradeName.Length < 3, "O Nome Fantasia deve ter no mínimo 3 caracteres.");
            DomainValidationException.When(tradeName.Length > 150, "O Nome Fantasia excede o limite máximo de caracteres.");

            DomainValidationException.When(leadPastor.Length > 100, "O nome do Pastor excede o limite máximo de caracteres.");

            // Denominação (Opcional na propriedade, mas validada se preenchida)
            if (!string.IsNullOrEmpty(denomination))
            {
                DomainValidationException.When(denomination.Length > 100, "A Denominação excede o limite máximo de caracteres.");
            }

            DomainValidationException.When(foundationDate > DateOnly.FromDateTime(DateTime.Now), "A Data de Fundação não pode ser uma data futura.");

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            DomainValidationException.When(!emailRegex.IsMatch(email), "O formato do E-mail é inválido.");

            // Validação de Site (Opcional ou Obrigatório dependendo da regra, aqui assumi obrigatório se vier preenchido)
            if (!string.IsNullOrWhiteSpace(website))
            {
                DomainValidationException.When(website.Length > 200, "A URL do site é muito longa.");
                bool isUri = Uri.TryCreate(website, UriKind.Absolute, out _);
                DomainValidationException.When(!isUri, "O Website informado não é uma URL válida (ex: https://...).");
            }
        }
    }
}
