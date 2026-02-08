namespace PlataformaRedencao.Application.DTOs.Auth
{
    public class RegisterUserRequestDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}