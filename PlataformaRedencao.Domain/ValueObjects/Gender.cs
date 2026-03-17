namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value object representing a person's gender in the domain.
    /// Closed set of valid values represented by persistible symbolic codes; immutable with value equality.
    /// </summary>
    public sealed class Gender : IEquatable<Gender>
    {
        /// <summary>
        /// Symbolic code representing the person's gender.
        /// Valid values: <c>M</c> (Male), <c>F</c> (Female). Used for persistence and cross-layer integration.
        /// </summary>
        public char Code { get; }

        /// <summary>
        /// Text description of the gender for semantic use and presentation in external layers.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Private constructor for controlled creation of valid value object instances.
        /// </summary>
        /// <param name="code">Symbolic code for the gender.</param>
        /// <param name="description">Text description of the gender.</param>
        private Gender(char code, string description)
        {
            Code = code;
            Description = description;
        }

        /// <summary>
        /// Male.
        /// </summary>
        public static readonly Gender Male = new('M', "Male");

        /// <summary>
        /// Female.
        /// </summary>
        public static readonly Gender Female = new('F', "Female");

        /// <summary>
        /// Creates a <see cref="Gender"/> instance from a symbolic code.
        /// </summary>
        /// <param name="code">Gender code (e.g. M, F).</param>
        /// <returns>Corresponding <see cref="Gender"/> instance.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the code is null, empty, or does not match a valid domain value.
        /// </exception>
        public static Gender FromCode(char code)
        {
            if (char.IsWhiteSpace(code))
                throw new ArgumentException("Gender code is required.");

            return char.ToUpperInvariant(code) switch
            {
                'M' => Male,
                'F' => Female,
                _ => throw new ArgumentException($"Invalid gender code: '{code}'.")
            };
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
            => Equals(obj as Gender);

        /// <summary>
        /// Determines whether another <see cref="Gender"/> is equal to this instance (by domain code).
        /// </summary>
        /// <param name="other">Another <see cref="Gender"/> instance.</param>
        /// <returns><c>true</c> if the codes are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Gender? other)
            => other is not null && Code == other.Code;

        /// <summary>
        /// Returns the hash code based on the domain value.
        /// </summary>
        /// <returns>Hash code of the object.</returns>
        public override int GetHashCode()
            => Code.GetHashCode();

        /// <summary>
        /// Equality operator for two <see cref="Gender"/> instances.
        /// </summary>
        public static bool operator ==(Gender left, Gender right)
            => Equals(left, right);

        /// <summary>
        /// Inequality operator for two <see cref="Gender"/> instances.
        /// </summary>
        public static bool operator !=(Gender left, Gender right)
            => !Equals(left, right);

        /// <summary>
        /// Returns the text description of the gender.
        /// </summary>
        /// <returns>Gender description.</returns>
        public override string ToString()
            => Description;
    }
}
