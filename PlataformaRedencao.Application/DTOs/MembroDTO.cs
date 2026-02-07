using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO para transferência de dados de membro.
    /// Valor de CPF e nomes são representados como strings para facilitar serialização.
    /// </summary>
    public class MembroDTO
    {
        public int Id { get; set; }
        public string Cpf { get; set; } = null!;
        public string PrimeiroNome { get; set; } = null!;
        public string SobreNome { get; set; } = null!;
        public string NomeCompleto => $"{PrimeiroNome} {SobreNome}";
        public DateOnly DataNascimento { get; set; }
        public char Sexo { get; set; }
        public ContatoDTO Contato { get; set; } = null!;
        public EstadoCivil EstadoCivil { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public int ProfissaoId { get; set; }
        public ProfissaoDTO? Profissao { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoDTO? Endereco { get; set; }
        public int IgrejaId { get; set; }
        public IgrejaDTO? Igreja { get; set; }
        public DateOnly DataAdmissao { get; set; }
        public TipoAdmissaoMembro TipoAdmissao { get; set; }
        public SituacaoMembro Situacao { get; set; }
    }
}