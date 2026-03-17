namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value object representing a person's contact information.
    /// Composed of a required valid email and an optional phone number.
    /// Immutable, has no identity of its own, and equality is defined by its values.
    /// </summary>
    public sealed class Contact : IEquatable<Contact>
    {
        /// <summary>
        /// Contact email address (required; must be valid per domain rules).
        /// </summary>
        public EmailAddress? EmailAddress { get; }

        /// <summary>
        /// Contact phone number (optional; fixed or mobile per <see cref="PhoneNumber"/> rules).
        /// </summary>
        public PhoneNumber? PhoneNumber { get; }

        /// <summary>
        /// Creates a new instance of <see cref="Contact"/>.
        /// </summary>
        /// <param name="emailAddress">Contact email (required).</param>
        /// <param name="phoneNumber">Contact phone (optional).</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the email is null.
        /// </exception>
        public Contact(EmailAddress? emailAddress, PhoneNumber? phoneNumber = null)
        {
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            PhoneNumber = phoneNumber;
        }

        #region Equality

        /// <summary>
        /// Determines whether another <see cref="Contact"/> is equal to this instance (same email and phone, or both without phone).
        /// </summary>
        /// <param name="other">Another <see cref="Contact"/> instance.</param>
        /// <returns><c>true</c> if the values are equivalent; otherwise, <c>false</c>.</returns>
        public bool Equals(Contact? other)
        {
            if (other is null) return false;

            return EmailAddress!.Equals(other.EmailAddress) &&
                   Equals(PhoneNumber, other.PhoneNumber);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
            => Equals(obj as Contact);

        /// <summary>
        /// Returns the hash code based on the contact values.
        /// </summary>
        /// <returns>Hash code of the object.</returns>
        public override int GetHashCode()
            => HashCode.Combine(EmailAddress, PhoneNumber);

        #endregion

        /// <summary>
        /// Returns the string representation of the contact (email only if no phone; otherwise email and phone).
        /// </summary>
        /// <returns>String representation of the contact.</returns>
        public override string ToString()
            => PhoneNumber is null
                ? EmailAddress!.ToString()
                : $"{EmailAddress} | {PhoneNumber}";
    }
}
