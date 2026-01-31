using Domain.ValueObjects;
using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.ValueObjects;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa um membro da igreja.
    /// </summary>
    /// <remarks>
    /// Esta classe concentra todos os dados de identificação pessoal,
    /// contato, situação e histórico eclesiástico.
    /// Um membro é um cidadão registrado (CPF), com nome, contato, endereço,
    /// profissão e demais informações civis, além de dados específicos
    /// relacionados à igreja, como data de admissão, tipo de admissão e situação.
    /// </remarks>
    public sealed class Membro : BaseEntity
    {
        private Membro() { }

        /// <summary>
        /// CPF da pessoa.
        /// </summary>
        public Cpf Cpf { get; private set; }

        /// <summary>
        /// Nome completo da pessoa.
        /// </summary>
        public NomePessoa NomePessoa { get; private set; }

        /// <summary>
        /// Data de nascimento da pessoa.
        /// </summary>
        public DateOnly DataNascimento { get; private set; }

        /// <summary>
        /// Sexo da pessoa.
        /// </summary>
        public Sexo Sexo { get; private set; }

        /// <summary>
        /// Informações de contato da pessoa.
        /// </summary>
        public Contato Contato { get; private set; }

        /// <summary>
        /// Estado civil da pessoa.
        /// </summary>
        public EstadoCivil EstadoCivil { get; private set; }

        /// <summary>
        /// Grau de escolaridade da pessoa.
        /// </summary>
        public Escolaridade Escolaridade { get; private set; }

        /// <summary>
        /// Profissão exercida pela pessoa.
        /// </summary>
        public Profissao Profissao { get; private set; }

        /// <summary>
        /// Identificador da profissão.
        /// </summary>
        public int ProfissaoId { get; private set; }

        /// <summary>
        /// Identificador do endereço.
        /// </summary>
        public int EnderecoId { get; private set; }

        /// <summary>
        /// Endereço da pessoa.
        /// </summary>
        public Endereco Endereco { get; private set; }

        /// <summary>
        /// Identificador da igreja à qual o membro pertence.
        /// </summary>
        /// <remarks>
        /// Chave estrangeira para a entidade <see cref="Igreja"/>.
        /// </remarks>
        public int IgrejaId { get; private set; }

        /// <summary>
        /// Igreja à qual o membro está vinculado.
        /// </summary>
        public Igreja Igreja { get; private set; }

        /// <summary>
        /// Data de admissão do membro na igreja.
        /// </summary>
        public DateOnly DataAdmissao { get; private set; }

        /// <summary>
        /// Tipo de admissão do membro.
        /// </summary>
        public TipoAdmissaoMembro TipoAdmissao { get; private set; }

        /// <summary>
        /// Situação atual do membro na igreja.
        /// </summary>
        public SituacaoMembro Situacao { get; private set; }

        /// <summary>
        /// Fábrica para criar um novo membro.
        /// </summary>
        public static Membro Criar(
            Cpf cpf,
            NomePessoa nomePessoa,
            Contato contato,
            DateOnly dataNascimento,
            Sexo sexo,
            Endereco endereco,
            Profissao profissao,
            Igreja igreja,
            DateOnly dataAdmissao,
            TipoAdmissaoMembro tipoAdmissao)
        {
            var membro = new Membro
            {
                Cpf = cpf,
                NomePessoa = nomePessoa,
                Contato = contato,
                DataNascimento = dataNascimento,
                Sexo = sexo,
                Endereco = endereco,
                EnderecoId = endereco.Id,
                Profissao = profissao,
                ProfissaoId = profissao.Id,
                Igreja = igreja,
                IgrejaId = igreja.Id,
                DataAdmissao = dataAdmissao,
                TipoAdmissao = tipoAdmissao,
                Situacao = SituacaoMembro.Ativo
            };

            return membro;
        }

        /// <summary>
        /// Atualiza os dados do membro.
        /// </summary>
        public void AtualizarMembro(
            DateOnly dataAdmissao,
            TipoAdmissaoMembro tipoAdmissao,
            SituacaoMembro situacao)
        {
            DataAdmissao = dataAdmissao;
            TipoAdmissao = tipoAdmissao;
            Situacao = situacao;
        }
    }
}
