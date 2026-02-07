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
    public abstract class Pessoa : BaseEntity
    {

        /// <summary>
        /// CPF da pessoa.
        /// </summary>
        /// <remarks>
        /// Identificador civil único no contexto nacional.
        /// Encapsulado em um Value Object para garantir:
        /// - Validação oficial
        /// - Imutabilidade
        /// - Integridade semântica
        /// </remarks>
        public Cpf Cpf { get; private set; }

        /// <summary>
        /// Nome completo da pessoa.
        /// </summary>
        /// <remarks>
        /// Encapsulado em um Value Object para garantir:
        /// - Validações estruturais
        /// - Imutabilidade
        /// - Coesão semântica
        /// Não contempla nome social.
        /// </remarks>
        public NomePessoa NomePessoa { get; private set; }

        /// <summary>
        /// Data de nascimento da pessoa.
        /// </summary>
        /// <remarks>
        /// Utiliza <see cref="DateOnly"/> para evitar ambiguidades
        /// relacionadas a horário e fuso.
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
        public int ProfissaoId { get; private set; }

        /// <summary>
        /// Endereço da pessoa.
        /// </summary>
        /// <remarks>
        /// Referência a entidade <see cref="Endereco"/> para
        /// permitir geolocalização, validação de endereço e consistência
        /// de dados.
        /// </remarks>
        public Endereco Endereco { get; private set; }
        public int EnderecoId { get; private set; }

        /// <summary>
        /// Lista de documentos associados à pessoa.
        /// </summary>
        /// <remarks>
        /// Representa documentos civis ou legais da pessoa.
        /// É exposta como leitura apenas para preservar a integridade.
        /// </remarks>
        public IReadOnlyCollection<Documento> Documentos =>
            _documentos.ToList().AsReadOnly();

        private readonly ICollection<Documento> _documentos = new HashSet<Documento>();

        /// <summary>
        /// Cria uma nova instância de <see cref="Pessoa"/> com dados essenciais.
        /// </summary>
        /// <remarks>
        /// O cadastro inicial NÃO implica concessão automática de consentimentos.
        /// </remarks>
        /// <param name="cpf">CPF da pessoa.</param>
        /// <param name="nomePessoa">Nome completo da pessoa.</param>
        /// <param name="dataNascimento">Data de nascimento da pessoa.</param>
        /// <param name="sexo">Sexo da pessoa.</param>
        /// <param name="endereco">Endereço da pessoa.</param>
        /// <param name="contato">Informações de contato da pessoa.</param>
        /// <param name="profissao">Profissão exercida pela pessoa.</param>
        /// <exception cref="ArgumentNullException">Quando algum valor essencial é nulo.</exception>
        public Pessoa(
            Cpf cpf,
            NomePessoa nomePessoa,
            DateOnly dataNascimento,
            Sexo sexo,
            Endereco endereco,
            Contato contato,
            Profissao profissao)
        {
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            NomePessoa = nomePessoa ?? throw new ArgumentNullException(nameof(nomePessoa));
            DataNascimento = dataNascimento;
            Sexo = sexo;

            Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
            EnderecoId = endereco.Id;

            Contato = contato ?? throw new ArgumentNullException(nameof(contato));
            Profissao = profissao ?? throw new ArgumentNullException(nameof(profissao));
        }
    }
}
