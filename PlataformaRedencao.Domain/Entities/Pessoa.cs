using Domain.ValueObjects;
using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.ValueObjects;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa uma pessoa física no domínio da plataforma.
    /// </summary>
    /// <remarks>
    /// A entidade <see cref="Pessoa"/> é um Aggregate Root e concentra
    /// exclusivamente dados estáveis de identificação, contato e
    /// situação pessoal.
    ///
    /// Informações voláteis, contextuais ou dependentes de política
    /// pública (como renda, elegibilidade ou benefícios) NÃO devem
    /// fazer parte desta entidade.
    ///
    /// Esta entidade não trata autenticação, autorização ou credenciais.
    /// </remarks>
    public class Pessoa : BaseEntity
    {
        /// <summary>
        /// Nome completo da pessoa.
        /// </summary>
        /// <remarks>
        /// Encapsulado em um Value Object para garantir:
        /// - Validações estruturais
        /// - Imutabilidade
        /// - Coesão semântica
        ///
        /// Não contempla nome social.
        /// </remarks>
        public NomeCompleto Nome { get; private set; }

        /// <summary>
        /// Data de nascimento da pessoa.
        /// </summary>
        /// <remarks>
        /// Utiliza <see cref="DateOnly"/> para evitar ambiguidades
        /// relacionadas a horário e fuso.
        ///
        /// Deve sempre representar uma data passada.
        /// </remarks>
        public DateOnly DataNascimento { get; private set; }

        /// <summary>
        /// Sexo da pessoa.
        /// </summary>
        /// <remarks>
        /// Utilizado para fins estatísticos, regulatórios ou
        /// regras específicas de política pública.
        /// </remarks>
        public Sexo Sexo { get; private set; }

        /// <summary>
        /// Informações de contato da pessoa.
        /// </summary>
        /// <remarks>
        /// Encapsula meios de comunicação como e-mail e telefone.
        /// </remarks>
        public Contato Contato { get; private set; }

        /// <summary>
        /// Estado civil da pessoa.
        /// </summary>
        /// <remarks>
        /// Utilizado quando necessário para regras de negócio
        /// ou análises estatísticas.
        /// </remarks>
        public EstadoCivil EstadoCivil { get; private set; }

        /// <summary>
        /// Grau de escolaridade da pessoa.
        /// </summary>
        /// <remarks>
        /// Informação declaratória, utilizada para análises
        /// e políticas públicas.
        /// </remarks>
        public Escolaridade Escolaridade { get; private set; }

        /// <summary>
        /// Profissão exercida pela pessoa.
        /// </summary>
        /// <remarks>
        /// Referência a uma entidade própria, permitindo
        /// reutilização, padronização e códigos oficiais (ex.: CBO).
        /// </remarks>
        public Profissao Profissao { get; private set; }

        /// <summary>
        /// Indica se o cadastro da pessoa está ativo no sistema.
        /// </summary>
        /// <remarks>
        /// Utilizado para desativação lógica, preservando
        /// histórico e integridade referencial.
        /// </remarks>
        public IReadOnlyCollection<Documento> Documentos => ((HashSet<Documento>)_documentos).ToList().AsReadOnly();

        /// <summary>
        /// Histórico de consentimentos concedidos pela pessoa.
        /// </summary>
        /// <remarks>
        /// Inclui consentimentos ativos e revogados.
        /// Nunca deve ser apagado ou sobrescrito.
        /// </remarks>
        public IReadOnlyCollection<Consentimento> Consentimentos => ((HashSet<Consentimento>)_consentimentos).ToList().AsReadOnly();

        private readonly ICollection<Documento> _documentos = new HashSet<Documento>();
        private readonly ICollection<Consentimento> _consentimentos = new HashSet<Consentimento>();

        public int EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }

        public int ProfissaoId { get; private set; }

        /// <summary>
        /// Cria uma nova instância de <see cref="Pessoa"/> com dados essenciais.
        /// </summary>
        /// <remarks>
        /// O cadastro inicial NÃO implica concessão automática
        /// de consentimentos.
        /// </remarks>
        public Pessoa(
            NomeCompleto nome,
            DateOnly dataNascimento,
            Sexo sexo,
            Endereco endereco,
            Contato contato,
            Profissao profissao)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            DataNascimento = dataNascimento;
            Sexo = sexo;

            Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
            EnderecoId = endereco.Id;

            Profissao = profissao ?? throw new ArgumentNullException(nameof(profissao));
            Contato = contato ?? throw new ArgumentNullException(nameof(contato));
        }
    }
}
