using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value object representing an identification document in the domain.
    /// Composed of a type (<see cref="DocumentType"/>) and an associated number.
    /// Immutable, has no identity of its own, and equality is defined by its values.
    /// </summary>
    public sealed class Document
    {
        /// <summary>
        /// Type of the identification document (e.g. CPF, RG, CNH, CNPJ) from a closed domain set.
        /// </summary>
        public DocumentType DocumentType { get; }

        /// <summary>
        /// Document number. Must match the document type; specific validation may be applied by specialized value objects (e.g. <c>Cpf</c>).
        /// </summary>
        public string? DocumentNumber { get; }

        private Document() { }

        /// <summary>
        /// Creates a new instance of <see cref="Document"/>.
        /// </summary>
        /// <param name="documentType">Document type.</param>
        /// <param name="documentNumber">Document number.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the document number is null or empty.
        /// </exception>
        public Document(DocumentType documentType, string documentNumber)
        {
            if (string.IsNullOrWhiteSpace(documentNumber))
                throw new ArgumentException("Document number cannot be empty.", nameof(documentNumber));

            DocumentType = documentType;
            DocumentNumber = documentNumber.Trim();
        }

        /// <summary>
        /// Returns the string representation of the document (type and number).
        /// </summary>
        /// <returns>String representation of the document.</returns>
        public override string ToString()
            => $"{DocumentType}: {DocumentNumber}";
    }
}
