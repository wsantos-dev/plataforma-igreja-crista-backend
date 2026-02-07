namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO que representa informações de contato (email e telefone).
    /// </summary>
    public class ContatoDTO
    {
        public string Email { get; set; } = null!;
        public string? Telefone { get; set; }
    }
}