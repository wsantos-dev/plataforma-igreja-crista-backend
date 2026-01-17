using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa um endereço genérico associado a qualquer entidade do domínio,
    /// mantendo histórico de vigência.
    /// </summary>
    public class Endereco : BaseEntity
    {

        /// <summary>
        /// Identificador da entidade dona do endereço.
        /// </summary>
        public int EntidadeId { get; private set; }

        /// <summary>
        /// Tipo da entidade dona do endereço.
        /// Ex.: Igreja, Membro, Pessoa, Visitante.
        /// </summary>
        public TipoEntidadeEndereco TipoEntidade { get; private set; }

        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string Telefone { get; private set; }

        /// <summary>
        /// Indica se este é o endereço atual do dono.
        /// </summary>
        public bool Atual { get; private set; }

        public DateTime VigenteDesde { get; private set; }
        public DateTime? VigenteAte { get; private set; }

        public Endereco(
            int entidadeId,
            TipoEntidadeEndereco tipoEntidade,
            string logradouro,
            string cidade,
            string estado,
            string pais,
            string telefone)
        {
            EntidadeId = entidadeId;
            TipoEntidade = tipoEntidade;
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Telefone = telefone;

            Atual = true;
            VigenteDesde = DateTime.UtcNow;
        }

        public void EncerrarVigencia()
        {
            Atual = false;
            VigenteAte = DateTime.UtcNow;
        }
    }
}
