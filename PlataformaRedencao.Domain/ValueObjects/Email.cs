using System.Text.RegularExpressions;

namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa um endereço de e-mail no domínio.
    /// 
    /// Este objeto encapsula as regras de validação de e-mail,
    /// garantindo que apenas valores válidos possam ser instanciados.
    /// 
    /// O e-mail é tratado como um valor imutável, sem identidade própria,
    /// e sua igualdade é definida pelo endereço, de forma case-insensitive.
    /// </summary>
    public sealed class Email : IEquatable<Email>
    {
        /// <summary>
        /// Expressão regular utilizada para validação básica
        /// do formato do endereço de e-mail.
        /// </summary>
        private static readonly Regex EmailRegex = new(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        /// <summary>
        /// Endereço de e-mail validado e normalizado.
        /// </summary>
        public string Endereco { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="Email"/> a partir
        /// de um endereço informado.
        /// </summary>
        /// <param name="endereco">Endereço de e-mail.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando o e-mail é nulo, vazio ou inválido.
        /// </exception>
        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("E-mail não pode ser vazio.", nameof(endereco));

            endereco = endereco.Trim();

            if (!EmailRegex.IsMatch(endereco))
                throw new ArgumentException("E-mail inválido.", nameof(endereco));

            Endereco = endereco;
        }

        /// <summary>
        /// Conversão implícita de <see cref="Email"/> para <see cref="string"/>.
        /// 
        /// Retorna o endereço de e-mail validado.
        /// </summary>
        public static implicit operator string(Email email)
            => email.Endereco;

        #region Equality

        /// <summary>
        /// Determina se outro <see cref="Email"/> é igual ao objeto atual.
        /// 
        /// A comparação é realizada de forma case-insensitive,
        /// conforme convenção de e-mails.
        /// </summary>
        /// <param name="other">Outro objeto <see cref="Email"/>.</param>
        /// <returns>
        /// <c>true</c> se os endereços forem equivalentes; caso contrário, <c>false</c>.
        /// </returns>
        public bool Equals(Email? other)
            => other is not null &&
               string.Equals(Endereco, other.Endereco, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        public override bool Equals(object? obj)
            => Equals(obj as Email);

        /// <summary>
        /// Retorna o código hash baseado no endereço de e-mail,
        /// utilizando comparação case-insensitive.
        /// </summary>
        public override int GetHashCode()
            => StringComparer.OrdinalIgnoreCase.GetHashCode(Endereco);

        #endregion

        /// <summary>
        /// Retorna a representação textual do e-mail.
        /// </summary>
        /// <returns>Endereço de e-mail.</returns>
        public override string ToString()
            => Endereco;
    }
}
