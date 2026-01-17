using System.ComponentModel;


namespace PlataformaRedencao.Domain.Enums
{
    public enum SituacaoMembro
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Afastado")]
        Afastado = 2,
        [Description("Desligado")]
        Desligado = 3,
        [Description("Falecido")]
        Falecido = 4
    }
}
