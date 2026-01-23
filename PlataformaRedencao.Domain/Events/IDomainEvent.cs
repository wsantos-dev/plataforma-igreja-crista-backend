namespace PlataformaRedencao.Domain.Events
{
    /// <summary>
    /// Marca um evento de domínio.
    /// </summary>
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}