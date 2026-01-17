using System.ComponentModel;

public enum ProvedorAssinatura
{
    [Description("Gov BR")]
    GovBr = 1,
    [Description("ICP Brasil")]
    ICPBrasil = 2,
    [Description("Outro")]
    Outro = 99
}
