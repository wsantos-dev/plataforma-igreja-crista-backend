using PlataformaRedencao.Domain.Validation;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Represents a profession held by a person.
    /// </summary>
    /// <remarks>
    /// Used as a reference to classify a person's occupation. Some professions have special meaning in the domain, such as the default "Not informed".
    /// </remarks>
    public sealed class Profession : BaseEntity
    {

        /// <summary>
        /// Profession name.
        /// </summary>
        public string Term { get; private set; }

        /// <summary>
        /// Official profession code (e.g. CBO).
        /// </summary>
        public string? Code { get; private set; }

        public Profession(int id, string term)
        {
            ValidateDomain(term);

            Term = term.Trim();
        }

        private void ValidateDomain(string term)
            => DomainValidationException.When(term is null, "O nome da profissão é obrigatório");
    }
}
