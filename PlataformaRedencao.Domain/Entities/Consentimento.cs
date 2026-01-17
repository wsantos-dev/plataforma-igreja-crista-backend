using PlataformaRedencao.Domain.Entities;


/// <summary>
/// Representa o consentimento explícito concedido por uma <see cref="Pessoa"/>
/// para o tratamento de seus dados pessoais, conforme exigências legais
/// (ex.: LGPD).
/// </summary>
/// <remarks>
/// O consentimento é uma entidade de domínio com identidade própria,
/// pois possui ciclo de vida, histórico e relevância jurídica.
/// 
/// Regras importantes:
/// - Um consentimento é concedido em um momento específico.
/// - A revogação não exclui o consentimento, apenas registra sua invalidação.
/// - Consentimentos não devem ser atualizados, apenas concedidos ou revogados.
/// - Cada tipo de consentimento pode ser concedido e revogado independentemente.
/// </remarks>
public sealed class Consentimento : BaseEntity
{
    /// <summary>
    /// Pessoa à qual o consentimento está vinculado.
    /// </summary>
    /// <remarks>
    /// Representa a relação explícita de domínio entre o titular dos dados
    /// e o consentimento concedido. Não deve ser nula.
    /// </remarks>
    public Pessoa? Pessoa { get; private set; }

    /// <summary>
    /// Tipo do consentimento concedido.
    /// </summary>
    /// <remarks>
    /// Define a finalidade jurídica do consentimento, como:
    /// uso de dados pessoais, compartilhamento com terceiros,
    /// comunicação ou fins estatísticos.
    /// 
    /// Cada tipo possui significado legal distinto e pode ser tratado
    /// de forma independente.
    /// </remarks>
    public TipoConsentimento Tipo { get; private set; }

    /// <summary>
    /// Data e hora em que o consentimento foi concedido.
    /// </summary>
    /// <remarks>
    /// Deve ser registrada no momento da concessão e nunca alterada,
    /// garantindo rastreabilidade e validade jurídica.
    /// </remarks>
    public DateTime DataConcessao { get; private set; }

    /// <summary>
    /// Data e hora em que o consentimento foi revogado, se aplicável.
    /// </summary>
    /// <remarks>
    /// Quando nula, indica que o consentimento está ativo.
    /// Quando preenchida, indica que o consentimento foi revogado
    /// e não deve mais ser considerado válido para processamento de dados.
    /// </remarks>
    public DateTime? DataRevogacao { get; private set; }
}
