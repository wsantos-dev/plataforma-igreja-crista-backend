using System.Text.RegularExpressions;

namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value object representing a phone number in the domain.
    /// Encapsulates validation and formatting of phone numbers, ensuring consistency and immutability.
    /// </summary>
    public sealed class PhoneNumber : IEquatable<PhoneNumber>
    {
        /// <summary>
        /// Regular expression used for basic validation of Brazilian phone numbers.
        /// </summary>
        private static readonly Regex PhoneRegex = new Regex(
            @"^\(?\d{2}\)?\s?9?\d{4}-?\d{4}$",
            RegexOptions.Compiled
        );

        /// <summary>
        /// Validated phone number.
        /// </summary>
        public string Number { get; }

        /// <summary>
        /// Creates a new instance of <see cref="PhoneNumber"/>.
        /// </summary>
        /// <param name="number">Phone number.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the number is null, empty, or invalid.
        /// </exception>
        public PhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number cannot be empty.", nameof(number));

            number = number.Trim();

            if (!PhoneRegex.IsMatch(number))
                throw new ArgumentException("Invalid phone number.", nameof(number));

            Number = number;
        }

        /// <summary>
        /// Formats the phone number in standard form: (XX) 9XXXX-XXXX.
        /// </summary>
        public string Format()
        {
            var digits = Regex.Replace(Number, @"\D", ""); // strip non-digits

            if (digits.Length == 11) // mobile with 9
                return $"({digits.Substring(0, 2)}) {digits.Substring(2, 5)}-{digits.Substring(7, 4)}";

            if (digits.Length == 10) // landline
                return $"({digits.Substring(0, 2)}) {digits.Substring(2, 4)}-{digits.Substring(6, 4)}";

            return Number; // fallback
        }

        /// <summary>
        /// Value object equality implementation (by value).
        /// </summary>
        public override bool Equals(object? obj)
            => Equals(obj as PhoneNumber);

        public bool Equals(PhoneNumber? other)
            => other is not null && Number == other.Number;

        public override int GetHashCode()
            => Number.GetHashCode();

        public override string ToString()
            => Format();
    }
}
