namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO que representa uma igreja para transferência de dados entre camadas.
    /// </summary>
    public class IgrejaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? NomeFantasia { get; set; }
        public string? Denominacao { get; set; }
        public string? PastorResponsavel { get; set; }
        public DateTime DataFundacao { get; set; }
        public string? Cnpj { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public bool Ativa { get; set; }
        public DateTime CriadaEm { get; set; }
        public DateTime? AtualizadaEm { get; set; }
        public int? EnderecoId { get; set; }
        public EnderecoDTO? Endereco { get; set; }
    }
}