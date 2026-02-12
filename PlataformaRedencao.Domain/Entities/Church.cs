using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
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
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Last update timestamp of the church record.
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; private set; }

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
            OfficialName = officialName;
            TradeName = tradeName;
            Denomination = denomination;
            LeadPastor = leadPastor;
            FoundationDate = foundationDate;
            Cnpj = cnpj;
            Email = email;
            Website = website;
            CreatedAt = DateTimeOffset.UtcNow;
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
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
