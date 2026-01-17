using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa o CPF (Cadastro de Pessoas Físicas)
    /// no domínio.
    /// 
    /// Este objeto encapsula todas as regras de validação do CPF,
    /// garantindo que apenas valores válidos possam ser instanciados.
    /// 
    /// O CPF é tratado como um valor imutável, sem identidade própria,
    /// com igualdade definida exclusivamente pelo seu conteúdo.
    /// </summary>
    public sealed class Cpf : IEquatable<Cpf>
    {
        /// <summary>
        /// Expressão regular utilizada para remover caracteres
        /// não numéricos do CPF informado.
        /// </summary>
        private static readonly Regex OnlyDigits =
            new(@"[^\d]", RegexOptions.Compiled);

        /// <summary>
        /// Valor numérico do CPF contendo exatamente 11 dígitos,
        /// sem formatação.
        /// </summary>
        public string Valor { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="Cpf"/> a partir de
        /// um valor informado.
        /// 
        /// São aceitos valores formatados ou não formatados
        /// (ex.: 123.456.789-09 ou 12345678909).
        /// </summary>
        /// <param name="valor">Valor do CPF.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando o CPF é nulo, vazio ou inválido segundo
        /// as regras oficiais de validação.
        /// </exception>
        public Cpf(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("CPF não pode ser vazio.", nameof(valor));

            var digits = OnlyDigits.Replace(valor, string.Empty);

            if (digits.Length != 11)
                throw new ArgumentException("CPF deve conter exatamente 11 dígitos.", nameof(valor));

            if (IsRepeatedDigits(digits))
                throw new ArgumentException("CPF inválido.", nameof(valor));

            if (!IsValidCheckDigits(digits))
                throw new ArgumentException("CPF inválido.", nameof(valor));

            Valor = digits;
        }

        /// <summary>
        /// Retorna o CPF formatado no padrão brasileiro:
        /// XXX.XXX.XXX-XX
        /// </summary>
        /// <returns>CPF formatado.</returns>
        public override string ToString()
            => $"{Valor[..3]}.{Valor.Substring(3, 3)}.{Valor.Substring(6, 3)}-{Valor.Substring(9, 2)}";

        #region Equality

        /// <summary>
        /// Determina se outro <see cref="Cpf"/> é igual ao objeto atual.
        /// 
        /// Dois CPFs são considerados iguais quando possuem
        /// exatamente o mesmo valor numérico.
        /// </summary>
        /// <param name="other">Outro objeto <see cref="Cpf"/>.</param>
        /// <returns>
        /// <c>true</c> se os valores forem iguais; caso contrário, <c>false</c>.
        /// </returns>
        public bool Equals(Cpf? other)
            => other is not null && Valor == other.Valor;

        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        public override bool Equals(object? obj)
            => Equals(obj as Cpf);

        /// <summary>
        /// Retorna o código hash baseado no valor do CPF.
        /// </summary>
        public override int GetHashCode()
            => Valor.GetHashCode();

        /// <summary>
        /// Conversão implícita de <see cref="Cpf"/> para <see cref="string"/>.
        /// 
        /// Retorna o valor numérico do CPF sem formatação.
        /// </summary>
        public static implicit operator string(Cpf cpf)
            => cpf.Valor;

        #endregion

        #region Validation

        /// <summary>
        /// Verifica se o CPF contém todos os dígitos iguais
        /// (ex.: 11111111111), o que o torna inválido.
        /// </summary>
        private static bool IsRepeatedDigits(string digits)
            => digits.All(c => c == digits[0]);

        /// <summary>
        /// Valida os dígitos verificadores do CPF conforme
        /// o algoritmo oficial.
        /// </summary>
        private static bool IsValidCheckDigits(string digits)
        {
            var numbers = digits.Select(c => c - '0').ToArray();

            // Primeiro dígito verificador
            var sum = 0;
            for (var i = 0; i < 9; i++)
                sum += numbers[i] * (10 - i);

            var firstCheck = (sum * 10) % 11;
            if (firstCheck == 10) firstCheck = 0;

            if (numbers[9] != firstCheck)
                return false;

            // Segundo dígito verificador
            sum = 0;
            for (var i = 0; i < 10; i++)
                sum += numbers[i] * (11 - i);

            var secondCheck = (sum * 10) % 11;
            if (secondCheck == 10) secondCheck = 0;

            return numbers[10] == secondCheck;
        }

        #endregion
    }
}
