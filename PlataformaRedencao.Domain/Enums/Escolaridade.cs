using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    public enum Escolaridade
    {
        [Description("Analfabeto(a)")]
        Analfabeto = 0,
        [Description("Ensino Fundamental Completo")]
        EnsinoFundamentalCompleto = 1,
        [Description("Ensino Fundamental Incompleto")]
        EnsinoFundamentalIncompleto = 2,
        [Description("Ensino Médio Completo")]
        EnsinoMedioCompleto = 3,
        [Description("Ensino Médio Incompleto")]
        EnsinoMedioIncompleto = 4,
        [Description("Superior Completo")]
        SuperiorCompleto = 5,
        [Description("Superior Incompleto")]
        SuperiorIncompleto = 6,
        [Description("Pós-Graduação")]
        PosGraduacao = 7,
        [Description("Mestrado")]
        Mestrado = 8,
        [Description("Doutorado")]
        Doutorado = 9
    }
}