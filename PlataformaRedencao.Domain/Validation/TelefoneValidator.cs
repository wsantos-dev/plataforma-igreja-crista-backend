using System.Text.RegularExpressions;

namespace PlataformaRedencao.Domain.Validation
{
    /// <summary>
    /// Classe utilitária responsável pela validação de números
    /// de telefone conforme regras definidas pelo domínio.
    /// 
    /// Esta validação é utilizada como apoio a Value Objects
    /// (ex.: <c>Telefone</c>), não representando por si só
    /// um conceito de domínio.
    /// </summary>
    public static class TelefoneValidator
    {
        /// <summary>
        /// Expressão regular utilizada para validar números de telefone
        /// móvel no padrão brasileiro, contendo:
        /// 
        /// - DDD válido (11 a 99, exceto combinações inválidas)
        /// - Dígito 9 obrigatório
        /// - Total de 11 dígitos numéricos
        /// 
        /// Exemplo válido: 11987654321
        /// </summary>
        private static readonly Regex TelefoneRegex =
            new(@"^(?:1[1-9]|[2-9]\d)9\d{8}$", RegexOptions.Compiled);

        /// <summary>
        /// Verifica se o número de telefone informado é válido
        /// segundo as regras do domínio.
        /// </summary>
        /// <param name="telefone">
        /// Número de telefone contendo apenas dígitos,
        /// incluindo DDD (ex.: 11987654321).
        /// </param>
        /// <returns>
        /// <c>true</c> se o telefone for válido; caso contrário, <c>false</c>.
        /// </returns>
        public static bool IsValid(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            return TelefoneRegex.IsMatch(telefone);
        }
    }
}
