using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa um membro de uma igreja.
    /// </summary>
    /// <remarks>
    /// A entidade <see cref="Membro"/> é uma especialização de <see cref="Pessoa"/>
    /// e representa o vínculo formal de uma pessoa com uma igreja local.
    ///'Membro': cannot derive from sealed type 'Pessoa'CS0509
    /// Nem toda pessoa cadastrada no sistema é necessariamente um membro.
    /// O vínculo como membro implica regras e responsabilidades específicas
    /// do contexto eclesiástico.
    /// </remarks>
    public sealed class Membro : Pessoa
    {
        /// <summary>
        /// Data de admissão do membro na igreja.
        /// </summary>
        /// <remarks>
        /// Normalmente corresponde à data de batismo, aclamação
        /// ou transferência, conforme o caso.
        /// </remarks>
        public DateOnly DataAdmissao { get; private set; }

        /// <summary>
        /// Tipo de admissão do membro.
        /// </summary>
        /// <remarks>
        /// Indica como o membro ingressou na igreja:
        /// batismo, aclamação ou transferência.
        /// </remarks>
        public TipoAdmissaoMembro TipoAdmissao { get; private set; }

        /// <summary>
        /// Situação atual do membro na igreja.
        /// </summary>
        /// <remarks>
        /// Controla o status eclesiástico do membro,
        /// como ativo, afastado, desligado ou falecido.
        /// </remarks>
        public SituacaoMembro Situacao { get; private set; }

        /// <summary>
        /// Indica se o membro está atualmente ativo.
        /// </summary>
        /// <remarks>
        /// Um membro inativo não participa das atividades regulares,
        /// mas seu histórico permanece preservado.
        /// </remarks>
        public bool Ativo { get; private set; }
        /// <summary>
        /// Cria um novo membro a partir de uma pessoa existente.
        /// </summary>
        /// <remarks>
        /// A criação de um membro representa um ato formal
        /// de ingresso na igreja.
        /// </remarks>
        public Membro(
            Pessoa pessoa,
            DateOnly dataAdmissao,
            TipoAdmissaoMembro tipoAdmissao)
            : base(
                pessoa.Nome,
                pessoa.DataNascimento,
                pessoa.Sexo,
                pessoa.Endereco,
                pessoa.Contato,
                pessoa.Profissao)
        {
            DataAdmissao = dataAdmissao;
            TipoAdmissao = tipoAdmissao;
            Situacao = SituacaoMembro.Ativo;
            Ativo = true;
        }

        /// <summary>
        /// Altera a situação eclesiástica do membro.
        /// </summary>
        public void AlterarSituacao(SituacaoMembro novaSituacao)
        {
            Situacao = novaSituacao;
            Ativo = novaSituacao == SituacaoMembro.Ativo;
        }
    }
}
