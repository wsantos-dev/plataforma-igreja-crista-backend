using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Define os tipos de entidades que podem possuir endereços.
    /// </summary>
    public enum TipoEntidadeEndereco
    {
        [Description("Igreja")]
        Igreja = 1,
        [Description("Membro")]
        Membro = 2,
        [Description("Visitante")]
        Visitante = 3
    }
}
