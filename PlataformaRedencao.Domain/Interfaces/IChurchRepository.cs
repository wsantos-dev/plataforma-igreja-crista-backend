using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    /// <summary>
    /// Repository for persistence operations on <see cref="Church"/> entities.
    /// </summary>
    public interface IChurchRepository : IRepository<Church>
    {
        /// <summary>
        /// Gets a church by CNPJ.
        /// </summary>
        /// <param name="cnpj">Church CNPJ.</param>
        /// <returns>The church or <c>null</c> if not found.</returns>
        Task<Church?> GetByCnpjAsync(string cnpj);

        /// <summary>
        /// Gets churches by denomination.
        /// </summary>
        /// <param name="denomination">Denomination name.</param>
        /// <returns>Churches of the given denomination.</returns>
        Task<IEnumerable<Church>> GetByDenominationAsync(string denomination);
    }
}