using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    public enum EstadoCivil
    {
        [Description("Solteiro(a)")]
        Solteiro,
        [Description("Casado(a)")]
        Casado,
        [Description("Viuvo(a)")]
        Viuvo,
        [Description("Divorciado(a)")]
        Divorciado
    }
}