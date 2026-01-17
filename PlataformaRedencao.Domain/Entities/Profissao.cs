namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa uma profissão exercida por uma pessoa.
    /// </summary>
    /// <remarks>
    /// A entidade <see cref="Profissao"/> é utilizada como referência
    /// para classificar a ocupação profissional de uma pessoa.
    ///
    /// Algumas profissões possuem significado especial no domínio,
    /// como a profissão padrão "Não informado".
    /// </remarks>
    public sealed class Profissao : BaseEntity
    {
        /// <summary>
        /// Código utilizado para representar profissão não informada.
        /// </summary>
        public const string CodigoNaoInformado = "0000";

        /// <summary>
        /// Nome da profissão.
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Código oficial da profissão (ex.: CBO).
        /// </summary>
        public string? Codigo { get; private set; }

        /// <summary>
        /// Indica se a profissão está ativa para uso no sistema.
        /// </summary>
        public bool Ativa { get; private set; }

        public Profissao(int id, string nome, string? codigo = null)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException(
                    "O nome da profissão não pode ser vazio.",
                    nameof(nome));

            Id = id;
            Nome = nome.Trim();
            Codigo = string.IsNullOrWhiteSpace(codigo) ? null : codigo.Trim();
            Ativa = true;
        }

        /// <summary>
        /// Indica se esta profissão representa o valor padrão
        /// "Não informado".
        /// </summary>
        public bool EhNaoInformada()
            => Codigo == CodigoNaoInformado;

        /// <summary>
        /// Cria a instância padrão de profissão "Não informado".
        /// </summary>
        /// <remarks>
        /// Deve ser utilizada exclusivamente para seed inicial
        /// ou cenários controlados de inicialização.
        /// </remarks>
        public static Profissao CriarNaoInformada()
        {
            const int IdPadrao = 999;
            return new Profissao(IdPadrao, "Não informado", CodigoNaoInformado);
        }

        public void Desativar()
        {
            Ativa = false;
        }
    }
}
