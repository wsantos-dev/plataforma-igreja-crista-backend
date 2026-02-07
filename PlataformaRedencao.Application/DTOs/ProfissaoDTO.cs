namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO simples para profissões.
    /// </summary>
    public class ProfissaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Codigo { get; set; }
    }
}