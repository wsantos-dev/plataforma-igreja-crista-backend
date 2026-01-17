using System;

namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa o sexo de uma pessoa no domínio.
    /// 
    /// Trata-se de um conceito de domínio com conjunto fechado de valores válidos,
    /// representados por códigos simbólicos persistíveis.
    /// 
    /// Este objeto é imutável e possui igualdade definida por valor.
    /// </summary>
    public sealed class Sexo : IEquatable<Sexo>
    {
        /// <summary>
        /// Código simbólico que representa o sexo da pessoa.
        /// 
        /// Valores válidos:
        /// <list type="bullet">
        /// <item><description><c>M</c> - Masculino</description></item>
        /// <item><description><c>F</c> - Feminino</description></item>
        /// </list>
        /// 
        /// Este código é utilizado para persistência e integração entre camadas.
        /// </summary>
        public string Codigo { get; }

        /// <summary>
        /// Descrição textual do sexo, destinada a uso semântico
        /// e apresentação em camadas externas.
        /// </summary>
        public string Descricao { get; }

        /// <summary>
        /// Construtor privado para garantir a criação controlada
        /// das instâncias válidas do Value Object.
        /// </summary>
        /// <param name="codigo">Código simbólico do sexo.</param>
        /// <param name="descricao">Descrição textual do sexo.</param>
        private Sexo(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        /// <summary>
        /// Representa o sexo masculino.
        /// </summary>
        public static readonly Sexo Masculino = new("M", "Masculino");

        /// <summary>
        /// Representa o sexo feminino.
        /// </summary>
        public static readonly Sexo Feminino = new("F", "Feminino");

        /// <summary>
        /// Cria uma instância de <see cref="Sexo"/> a partir de um código simbólico.
        /// </summary>
        /// <param name="codigo">Código do sexo (ex.: M, F).</param>
        /// <returns>Instância correspondente de <see cref="Sexo"/>.</returns>
        /// <exception cref="ArgumentException">
        /// Lançada quando o código é nulo, vazio ou não corresponde a um valor válido do domínio.
        /// </exception>
        public static Sexo FromCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("Código do sexo é obrigatório.");

            return codigo.Trim().ToUpper() switch
            {
                "M" => Masculino,
                "F" => Feminino,
                _ => throw new ArgumentException($"Código de sexo inválido: {codigo}")
            };
        }

        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado.</param>
        /// <returns>
        /// <c>true</c> se os objetos forem iguais; caso contrário, <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
            => Equals(obj as Sexo);

        /// <summary>
        /// Determina se outro <see cref="Sexo"/> é igual ao objeto atual,
        /// com base no código do domínio.
        /// </summary>
        /// <param name="other">Outro objeto <see cref="Sexo"/>.</param>
        /// <returns>
        /// <c>true</c> se os códigos forem iguais; caso contrário, <c>false</c>.
        /// </returns>
        public bool Equals(Sexo? other)
            => other is not null && Codigo == other.Codigo;

        /// <summary>
        /// Retorna o código hash baseado no valor do domínio.
        /// </summary>
        /// <returns>Código hash do objeto.</returns>
        public override int GetHashCode()
            => Codigo.GetHashCode();

        /// <summary>
        /// Operador de igualdade entre dois objetos <see cref="Sexo"/>.
        /// </summary>
        public static bool operator ==(Sexo left, Sexo right)
            => Equals(left, right);

        /// <summary>
        /// Operador de desigualdade entre dois objetos <see cref="Sexo"/>.
        /// </summary>
        public static bool operator !=(Sexo left, Sexo right)
            => !Equals(left, right);

        /// <summary>
        /// Retorna a descrição textual do sexo.
        /// </summary>
        /// <returns>Descrição do sexo.</returns>
        public override string ToString()
            => Descricao;
    }
}
