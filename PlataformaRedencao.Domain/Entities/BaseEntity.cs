namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Classe base abstrata para entidades do domínio.
    /// 
    /// Fornece a identificação única da entidade, que a diferencia
    /// de outras instâncias do mesmo tipo.
    /// 
    /// Esta classe deve ser herdada apenas por entidades que possuam
    /// identidade própria e ciclo de vida no domínio.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Identificador único da entidade.
        /// 
        /// Este identificador define a identidade da entidade no domínio
        /// e é normalmente atribuído pela camada de persistência.
        /// </summary>
        public int Id { get; protected set; }

        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }
        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
