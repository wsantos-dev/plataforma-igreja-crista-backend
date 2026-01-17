using System.ComponentModel;

public enum TipoConsentimento
{
    [Description("Uso de Dados Pessoais")]
    UsoDadosPessoais = 1,
    [Description("Compartilhamento a Terceiros")]
    CompartilhamentoTerceiros = 2,
    [Description("Comunicação")]
    Comunicacao = 3,
    [Description("Processamento Legal")]
    ProcessamentoLegal = 4,
    [Description("Fins Estatísticos")]
    FinsEstatisticos = 5
}
