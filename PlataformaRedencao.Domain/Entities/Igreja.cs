using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Aggregate Root que representa uma Igreja Evangélica
    /// dentro do domínio da Plataforma Redenção.
    /// </summary>
    public class Igreja
    {
        /// <summary>
        /// Identificador único da igreja.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nome oficial da igreja.
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Nome fantasia ou nome curto utilizado publicamente.
        /// </summary>
        public string NomeFantasia { get; private set; }

        /// <summary>
        /// Denominação à qual a igreja pertence.
        /// </summary>
        public string Denominacao { get; private set; }

        /// <summary>
        /// Pastor presidente ou líder principal da igreja.
        /// </summary>
        public string PastorResponsavel { get; private set; }

        /// <summary>
        /// Data de fundação da igreja.
        /// </summary>
        public DateTime DataFundacao { get; private set; }

        /// <summary>
        /// Número de registro legal da igreja (CNPJ).
        /// </summary>
        public string Cnpj { get; private set; }

        /// <summary>
        /// E-mail institucional da igreja.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Site oficial da igreja.
        /// </summary>
        public string Site { get; private set; }

        /// <summary>
        /// Indica se a igreja está ativa no sistema.
        /// </summary>
        public bool Ativa { get; private set; }

        /// <summary>
        /// Data de criação do registro da igreja no sistema.
        /// </summary>
        public DateTime CriadaEm { get; private set; }

        /// <summary>
        /// Data da última atualização do cadastro da igreja.
        /// </summary>
        public DateTime? AtualizadaEm { get; private set; }

        /// <summary>
        /// Histórico de endereços associados à igreja.
        /// 
        /// Os endereços são entidades genéricas, vinculadas
        /// pela combinação (TipoEntidadeEndereco, EntidadeId).
        /// </summary>
        private readonly List<Endereco> _enderecos = new();
        public IReadOnlyCollection<Endereco> Enderecos => _enderecos;

        /// <summary>
        /// Cria uma nova instância de igreja.
        /// </summary>
        public Igreja(
            string nome,
            string nomeFantasia,
            string denominacao,
            string pastorResponsavel,
            DateTime dataFundacao,
            string cnpj,
            string email,
            string site)
        {
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Denominacao = denominacao;
            PastorResponsavel = pastorResponsavel;
            DataFundacao = dataFundacao;
            Cnpj = cnpj;
            Email = email;
            Site = site;

            Ativa = true;
            CriadaEm = DateTime.UtcNow;
        }

        /// <summary>
        /// Define um novo endereço para a igreja,
        /// encerrando o endereço atual, se existir.
        /// </summary>
        public void AlterarEndereco(
            string logradouro,
            string cidade,
            string estado,
            string pais,
            string telefone)
        {
            var enderecoAtual = _enderecos.FirstOrDefault(e =>
                e.TipoEntidade == TipoEntidadeEndereco.Igreja &&
                e.EntidadeId == Id &&
                e.Atual);

            enderecoAtual?.EncerrarVigencia();

            var novoEndereco = new Endereco(
                entidadeId: Id,
                tipoEntidade: TipoEntidadeEndereco.Igreja,
                logradouro: logradouro,
                cidade: cidade,
                estado: estado,
                pais: pais,
                telefone: telefone
            );

            _enderecos.Add(novoEndereco);
            AtualizadaEm = DateTime.UtcNow;
        }

        /// <summary>
        /// Desativa a igreja no sistema.
        /// </summary>
        public void Desativar()
        {
            Ativa = false;
            AtualizadaEm = DateTime.UtcNow;
        }

        /// <summary>
        /// Reativa a igreja no sistema.
        /// </summary>
        public void Reativar()
        {
            Ativa = true;
            AtualizadaEm = DateTime.UtcNow;
        }
    }
}
