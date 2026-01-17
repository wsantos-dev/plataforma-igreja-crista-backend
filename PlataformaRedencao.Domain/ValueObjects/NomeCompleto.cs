namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Representa o nome civil completo de uma pessoa.
    /// </summary>
    /// <remarks>
    /// <see cref="NomeCompleto"/> é um Value Object e, portanto:
    /// - Não possui identidade própria.
    /// - É imutável após sua criação.
    /// - É comparado por valor.
    /// 
    /// Este objeto encapsula o nome e o sobrenome conforme
    /// registro civil da pessoa.
    /// </remarks>
    public sealed class NomeCompleto
    {
        /// <summary>
        /// Nome civil da pessoa.
        /// </summary>
        /// <remarks>
        /// Corresponde ao prenome registrado oficialmente.
        /// </remarks>
        public string Nome { get; }

        /// <summary>
        /// Sobrenome da pessoa.
        /// </summary>
        /// <remarks>
        /// Representa o nome de família conforme registro civil.
        /// </remarks>
        public string Sobrenome { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="NomeCompleto"/>.
        /// </summary>
        /// <param name="nome">Nome civil da pessoa.</param>
        /// <param name="sobrenome">Sobrenome da pessoa.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando nome ou sobrenome são inválidos.
        /// </exception>
        public NomeCompleto(string nome, string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio.", nameof(nome));

            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException("O sobrenome não pode ser vazio.", nameof(sobrenome));

            Nome = nome.Trim();
            Sobrenome = sobrenome.Trim();
        }

        /// <summary>
        /// Retorna o nome completo formatado.
        /// </summary>
        public override string ToString()
            => $"{Nome} {Sobrenome}";

        /// <summary>
        /// Compara dois <see cref="NomeCompleto"/> por valor.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not NomeCompleto other)
                return false;

            return Nome == other.Nome
                && Sobrenome == other.Sobrenome;
        }

        /// <summary>
        /// Gera o código hash com base nos valores do objeto.
        /// </summary>
        public override int GetHashCode()
            => HashCode.Combine(Nome, Sobrenome);
    }
}
