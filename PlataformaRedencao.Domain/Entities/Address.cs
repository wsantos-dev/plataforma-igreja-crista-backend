using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Represents a generic address associated with any domain entity,
    /// with validity history and an indicator for the current address.
    /// </summary>
    /// <remarks>
    /// <see cref="Address"/> can be associated with different entity types,
    /// such as Member, Church, Person or Visitor, via <see cref="EntityAddressType"/>.
    /// Supports validity tracking to record periods when the address was valid.
    /// </remarks>
    public sealed class Address : BaseEntity
    {
        /// <summary>
        /// Identifier of the entity that owns this address.
        /// </summary>
        /// <remarks>
        /// Represents the key of the entity that owns this address.
        /// </remarks>
        public int EntityId { get; private set; }

        /// <summary>
        /// Type of the entity that owns this address.
        /// </summary>
        /// <remarks>
        /// Classifies the owning entity, e.g. Member, Church, Person or Visitor.
        /// </remarks>
        public EntityAddressType EntityType { get; private set; }

        /// <summary>
        /// Street name and type (e.g. street, avenue).
        /// </summary>
        public string? Street { get; private set; }

        /// <summary>
        /// Street or building number.
        /// </summary>
        public string? Number { get; private set; }

        /// <summary>
        /// Address complement (e.g. apartment, suite).
        /// </summary>
        public string? Complement { get; private set; }

        /// <summary>
        /// Neighborhood or district.
        /// </summary>
        public string? Neighborhood { get; private set; }

        /// <summary>
        /// City.
        /// </summary>
        public string? City { get; private set; }

        /// <summary>
        /// State or province.
        /// </summary>
        public string? State { get; private set; }

        /// <summary>
        /// Country.
        /// </summary>
        public string? Country { get; private set; }

        /// <summary>
        /// Postal or ZIP code.
        /// </summary>
        public string? PostalCode { get; private set; }

        /// <summary>
        /// Initializes a new address associated with a domain entity.
        /// </summary>
        /// <param name="entityId">Identifier of the entity that owns the address.</param>
        /// <param name="entityType">Type of the entity that owns the address.</param>
        /// <param name="street">Street name.</param>
        /// <param name="complement">Address complement.</param>
        /// <param name="number">Street or building number.</param>
        /// <param name="city">City.</param>
        /// <param name="state">State or province.</param>
        /// <param name="country">Country.</param>
        /// <param name="postalCode">Postal or ZIP code.</param>
        public Address(
            int entityId,
            EntityAddressType entityType,
            string street,
            string complement,
            string number,
            string city,
            string state,
            string country,
            string postalCode)
        {
            EntityId = entityId;
            EntityType = entityType;
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
        }
    }
}
