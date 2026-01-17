using System;
using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa um documento de identificação
    /// no domínio.
    /// 
    /// Um documento é composto por um tipo (<see cref="TipoDocumento"/>)
    /// e por um número associado a esse tipo.
    /// 
    /// Este objeto é imutável, não possui identidade própria
    /// e sua igualdade deve ser definida exclusivamente pelos valores
    /// que o compõem.
    /// </summary>
    public sealed class Documento
    {
        /// <summary>
        /// Tipo do documento de identificação.
        /// 
        /// Define a natureza do documento (ex.: CPF, RG, CNH, CNPJ),
        /// conforme conjunto fechado estabelecido pelo domínio.
        /// </summary>
        public TipoDocumento Tipo { get; }

        /// <summary>
        /// Número do documento.
        /// 
        /// Deve representar o valor do documento conforme o tipo informado.
        /// As regras de validação específicas podem ser aplicadas
        /// em camadas superiores ou por Value Objects especializados
        /// (ex.: <c>Cpf</c>, <c>Cnpj</c>).
        /// </summary>
        public string Numero { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="Documento"/>.
        /// </summary>
        /// <param name="tipo">Tipo do documento.</param>
        /// <param name="numero">Número do documento.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando o número do documento é nulo ou vazio.
        /// </exception>
        public Documento(TipoDocumento tipo, string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Número do documento não pode ser vazio.", nameof(numero));

            Tipo = tipo;
            Numero = numero.Trim();
        }

        /// <summary>
        /// Retorna a representação textual do documento,
        /// combinando tipo e número.
        /// </summary>
        /// <returns>Representação textual do documento.</returns>
        public override string ToString()
            => $"{Tipo}: {Numero}";
    }
}
