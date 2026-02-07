using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO para representar endereços.
    /// </summary>
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public int EntidadeId { get; set; }
        public TipoEntidadeEndereco TipoEntidade { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? Cep { get; set; }
        public bool Atual { get; set; }
        public DateTime? VigenteDesde { get; set; }
        public DateTime? VigenteAte { get; set; }
    }
}