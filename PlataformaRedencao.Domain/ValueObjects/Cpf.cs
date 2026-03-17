using System.Text.RegularExpressions;

namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value object representing a Brazilian CPF (individual taxpayer registry) in the domain.
    /// Encapsulates all CPF validation rules so that only valid values can be instantiated.
    /// The CPF is immutable, has no identity of its own, and equality is defined solely by its content.
    /// </summary>
    public sealed class Cpf : IEquatable<Cpf>
    {
        /// <summary>
        /// Regular expression used to strip non-numeric characters from the CPF value.
        /// </summary>
        private static readonly Regex OnlyDigitsRegex =
            new(@"[^\d]", RegexOptions.Compiled);

        /// <summary>
        /// Numeric value of the CPF containing exactly 11 digits, unformatted.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new instance of <see cref="Cpf"/> from the given value.
        /// Accepts formatted or unformatted values (e.g. 123.456.789-09 or 12345678909).
        /// </summary>
        /// <param name="value">CPF value.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the CPF is null, empty, or invalid according to official validation rules.
        /// </exception>
        public Cpf(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CPF cannot be empty.", nameof(value));

            var digits = OnlyDigitsRegex.Replace(value, string.Empty);

            if (digits.Length != 11)
                throw new ArgumentException("CPF must contain exactly 11 digits.", nameof(value));

            if (HasRepeatedDigits(digits))
                throw new ArgumentException("Invalid CPF.", nameof(value));

            if (!HasValidCheckDigits(digits))
                throw new ArgumentException("Invalid CPF.", nameof(value));

            Value = digits;
        }

        /// <summary>
        /// Returns the CPF formatted in Brazilian standard: XXX.XXX.XXX-XX.
        /// </summary>
        /// <returns>Formatted CPF.</returns>
        public override string ToString()
            => $"{Value[..3]}.{Value.Substring(3, 3)}.{Value.Substring(6, 3)}-{Value.Substring(9, 2)}";

        #region Equality

        /// <summary>
        /// Determines whether another <see cref="Cpf"/> is equal to this instance (same numeric value).
        /// </summary>
        /// <param name="other">Another <see cref="Cpf"/> instance.</param>
        /// <returns><c>true</c> if the values are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Cpf? other)
            => other is not null && Value == other.Value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        public override bool Equals(object? obj)
            => Equals(obj as Cpf);

        /// <summary>
        /// Returns the hash code based on the CPF value.
        /// </summary>
        public override int GetHashCode()
            => Value.GetHashCode();

        /// <summary>
        /// Implicit conversion from <see cref="Cpf"/> to <see cref="string"/>.
        /// Returns the numeric CPF value without formatting.
        /// </summary>
        public static implicit operator string(Cpf cpf)
            => cpf.Value;

        #endregion

        #region Validation

        /// <summary>
        /// Checks whether the CPF has all digits equal (e.g. 11111111111), which makes it invalid.
        /// </summary>
        private static bool HasRepeatedDigits(string digits)
            => digits.All(c => c == digits[0]);

        /// <summary>
        /// Validates the CPF check digits according to the official algorithm.
        /// </summary>
        private static bool HasValidCheckDigits(string digits)
        {
            var numbers = digits.Select(c => c - '0').ToArray();

            // First check digit
            var sum = 0;
            for (var i = 0; i < 9; i++)
                sum += numbers[i] * (10 - i);

            var firstCheckDigit = (sum * 10) % 11;
            if (firstCheckDigit == 10) firstCheckDigit = 0;

            if (numbers[9] != firstCheckDigit)
                return false;

            // Second check digit
            sum = 0;
            for (var i = 0; i < 10; i++)
                sum += numbers[i] * (11 - i);

            var secondCheckDigit = (sum * 10) % 11;
            if (secondCheckDigit == 10) secondCheckDigit = 0;

            return numbers[10] == secondCheckDigit;
        }

        #endregion
    }
}
