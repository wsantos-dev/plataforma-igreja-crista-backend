using System;
using PlataformaRedencao.Domain.ValueObjects;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa as informações de contato de uma pessoa.
    /// 
    /// Um contato é composto obrigatoriamente por um e-mail válido e,
    /// opcionalmente, por um telefone.
    /// 
    /// Este objeto é imutável, não possui identidade própria e sua igualdade
    /// é definida exclusivamente pelos valores que o compõem.
    /// </summary>
    public sealed class Contato : IEquatable<Contato>
    {
        /// <summary>
        /// Endereço de e-mail do contato.
        /// 
        /// Este campo é obrigatório e deve representar um e-mail válido
        /// segundo as regras do domínio.
        /// </summary>
        public Email Email { get; }

        /// <summary>
        /// Telefone do contato.
        /// 
        /// Campo opcional, podendo representar telefone fixo ou móvel,
        /// conforme regras definidas no Value Object <see cref="Telefone"/>.
        /// </summary>
        public Telefone? Telefone { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="Contato"/>.
        /// </summary>
        /// <param name="email">E-mail do contato (obrigatório).</param>
        /// <param name="telefone">Telefone do contato (opcional).</param>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o e-mail informado é nulo.
        /// </exception>
        public Contato(Email email, Telefone? telefone = null)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Telefone = telefone;
        }

        #region Equality

        /// <summary>
        /// Determina se outro objeto <see cref="Contato"/> é igual ao objeto atual.
        /// 
        /// Dois contatos são considerados iguais quando possuem o mesmo e-mail
        /// e o mesmo telefone (ou ambos sem telefone).
        /// </summary>
        /// <param name="other">Outro objeto <see cref="Contato"/>.</param>
        /// <returns>
        /// <c>true</c> se os valores forem equivalentes; caso contrário, <c>false</c>.
        /// </returns>
        public bool Equals(Contato? other)
        {
            if (other is null) return false;

            return Email.Equals(other.Email) &&
                   Equals(Telefone, other.Telefone);
        }

        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado.</param>
        /// <returns>
        /// <c>true</c> se os objetos forem iguais; caso contrário, <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
            => Equals(obj as Contato);

        /// <summary>
        /// Retorna o código hash baseado nos valores do contato.
        /// </summary>
        /// <returns>Código hash do objeto.</returns>
        public override int GetHashCode()
            => HashCode.Combine(Email, Telefone);

        #endregion

        /// <summary>
        /// Retorna a representação textual do contato.
        /// 
        /// Caso o telefone não esteja presente, retorna apenas o e-mail.
        /// Caso contrário, retorna e-mail e telefone concatenados.
        /// </summary>
        /// <returns>Representação textual do contato.</returns>
        public override string ToString()
            => Telefone is null
                ? Email.ToString()
                : $"{Email} | {Telefone}";
    }
}
