namespace PlataformaRedencao.Domain.Entities;

public sealed class Usuario : BaseEntity
{
    public string Email { get; private set; } = null!;
    public string SenhaHash { get; private set; } = null!;

    public bool IsAtivo { get; private set; }
    public DateTime CriadoEm { get; private set; }

    protected Usuario() { }

    public Usuario(string email, string senhaHash)
    {
        Email = email;
        SenhaHash = senhaHash;
        IsAtivo = true;
        CriadoEm = DateTime.Now;
    }
    public void Desativar()
    {
        IsAtivo = false;
    }
}
