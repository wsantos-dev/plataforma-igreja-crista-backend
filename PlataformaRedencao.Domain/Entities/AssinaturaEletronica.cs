using PlataformaRedencao.Domain.Entities;


/// <summary>
/// Representa a assinatura eletrônica associada a um <see cref="Consentimento"/>,
/// utilizada como prova jurídica da manifestação de vontade do titular dos dados.
/// </summary>
/// <remarks>
/// A <see cref="AssinaturaEletronica"/> é uma entidade de domínio com identidade
/// própria, pois:
/// - Possui valor probatório.
/// - É emitida por um provedor de identidade ou certificação.
/// - Está vinculada a um conteúdo específico por meio de hash criptográfico.
/// 
/// A assinatura garante:
/// - A identificação do titular.
/// - A integridade do conteúdo assinado.
/// - A data e hora do ato de assinatura.
/// 
/// Uma assinatura eletrônica NÃO deve ser alterada após sua criação.
/// Qualquer novo aceite exige uma nova assinatura.
/// </remarks>
public sealed class AssinaturaEletronica : BaseEntity
{
    /// <summary>
    /// Consentimento ao qual esta assinatura eletrônica está vinculada.
    /// </summary>
    /// <remarks>
    /// Define a relação direta entre o ato jurídico (consentimento)
    /// e o meio de comprovação (assinatura).
    /// 
    /// A assinatura não possui validade fora do contexto do consentimento
    /// ao qual está associada.
    /// </remarks>
    public Consentimento? Consentimento { get; private set; }

    /// <summary>
    /// Provedor responsável pela emissão e validação da assinatura eletrônica.
    /// </summary>
    /// <remarks>
    /// Identifica a entidade que realizou a autenticação do titular
    /// e garantiu sua identidade.
    /// 
    /// Exemplos:
    /// - gov.br
    /// - ICP-Brasil
    /// - Outros provedores homologados
    /// </remarks>
    public ProvedorAssinatura Provedor { get; private set; }

    /// <summary>
    /// Tipo da assinatura eletrônica, conforme nível de segurança e garantia jurídica.
    /// </summary>
    /// <remarks>
    /// Classificação baseada na Lei nº 14.063/2020:
    /// - Simples: baixo nível de garantia
    /// - Avançada: médio nível de garantia (ex.: gov.br)
    /// - Qualificada: alto nível de garantia (certificado digital ICP-Brasil)
    /// </remarks>
    public TipoAssinatura Tipo { get; private set; }

    /// <summary>
    /// Data e hora em que a assinatura eletrônica foi realizada.
    /// </summary>
    /// <remarks>
    /// Representa o momento exato da manifestação de vontade do titular.
    /// 
    /// Deve ser registrada de forma imutável e preferencialmente em UTC,
    /// garantindo consistência temporal e validade jurídica.
    /// </remarks>
    public DateTime DataAssinatura { get; private set; }

    /// <summary>
    /// Hash criptográfico do conteúdo assinado.
    /// </summary>
    /// <remarks>
    /// Garante a integridade do documento ou termo de consentimento,
    /// permitindo comprovar que o conteúdo não foi alterado após a assinatura.
    /// 
    /// O hash deve ser gerado a partir do conteúdo exato apresentado
    /// ao titular no momento da assinatura.
    /// </remarks>
    public string? HashDocumento { get; private set; }

    /// <summary>
    /// Identificador único da assinatura retornado pelo provedor externo.
    /// </summary>
    /// <remarks>
    /// Pode representar:
    /// - Token de autenticação
    /// - Identificador de transação
    /// - Código de validação
    /// 
    /// Utilizado para auditoria, verificação posterior e contestação jurídica.
    /// </remarks>
    public string? IdentificadorAssinatura { get; private set; }

    /// <summary>
    /// Informações do certificado digital ou metadados públicos da assinatura.
    /// </summary>
    /// <remarks>
    /// Pode conter:
    /// - Cadeia do certificado digital
    /// - Thumbprint
    /// - Dados públicos de validação
    /// 
    /// Este campo é opcional e sua presença depende do tipo e do provedor
    /// da assinatura eletrônica.
    /// </remarks>
    public string? Certificado { get; private set; }
}
