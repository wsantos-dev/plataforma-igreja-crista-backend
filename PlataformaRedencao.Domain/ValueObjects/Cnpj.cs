namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value object representing a Brazilian CNPJ (company taxpayer registry) in the domain.
    /// Encapsulates all CNPJ validation rules so that only valid values can be instantiated.
    /// The CNPJ is immutable, has no identity of its own, and equality is defined solely by its content.
    /// </summary>
    public sealed class Cnpj : IEquatable<Cnpj>
    {
        /// <summary>
        /// Numeric value of the CNPJ containing exactly 14 digits, unformatted.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new instance of <see cref="Cnpj"/> from the given value.
        /// Accepts formatted or unformatted values (e.g. 12.345.678/0001-95 or 12345678000195).
        /// </summary>
        /// <param name="value">CNPJ value.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the CNPJ is null, empty, or invalid according to official validation rules.
        /// </exception>
        public Cnpj(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CNPJ cannot be empty.", nameof(value));

            var digits = new string(value.Where(char.IsDigit).ToArray());

            if (digits.Length != 14)
                throw new ArgumentException("CNPJ must contain exactly 14 digits.", nameof(value));

            if (HasRepeatedDigits(digits))
                throw new ArgumentException("Invalid CNPJ.", nameof(value));

            if (!HasValidCheckDigits(digits))
                throw new ArgumentException("Invalid CNPJ.", nameof(value));

            Value = digits;
        }

        /// <summary>
        /// Returns the CNPJ formatted in Brazilian standard: XX.XXX.XXX/XXXX-XX.
        /// </summary>
        public override string ToString()
            => $"{Value[..2]}.{Value.Substring(2, 3)}.{Value.Substring(5, 3)}/{Value.Substring(8, 4)}-{Value.Substring(12, 2)}";

        #region Equality

        public bool Equals(Cnpj? other)
            => other is not null && Value == other.Value;

        public override bool Equals(object? obj)
            => Equals(obj as Cnpj);

        public override int GetHashCode()
            => Value.GetHashCode();

        public static implicit operator string(Cnpj cnpj)
            => cnpj.Value;

        #endregion

        #region Validation

        /// <summary>
        /// Checks whether the CNPJ has all digits equal (e.g. 11111111111111), which makes it invalid.
        /// </summary>
        private static bool HasRepeatedDigits(string digits)
            => digits.All(c => c == digits[0]);

        /// <summary>
        /// Validates the CNPJ check digits according to the official algorithm.
        /// </summary>
        private static bool HasValidCheckDigits(string digits)
        {
            var numbers = digits.Select(c => c - '0').ToArray();

            // First check digit weights
            int[] firstWeights = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var sum = 0;
            for (var i = 0; i < 12; i++)
                sum += numbers[i] * firstWeights[i];

            var remainder = sum % 11;
            var firstCheckDigit = remainder < 2 ? 0 : 11 - remainder;

            if (numbers[12] != firstCheckDigit)
                return false;

            // Second check digit weights
            int[] secondWeights = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            sum = 0;
            for (var i = 0; i < 13; i++)
                sum += numbers[i] * secondWeights[i];

            remainder = sum % 11;
            var secondCheckDigit = remainder < 2 ? 0 : 11 - remainder;

            return numbers[13] == secondCheckDigit;
        }

        #endregion
    }
}
