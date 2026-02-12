using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    /// <summary>
    /// Repository for persistence operations on <see cref="Member"/> entities.
    /// </summary>
    public interface IMemberRepository : IRepository<Member>
    {
        /// <summary>
        /// Gets a member by CPF and church.
        /// </summary>
        /// <param name="cpf">Member CPF.</param>
        /// <param name="churchId">Church id.</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        Task<Member?> GetByCpfAsync(string cpf, int churchId);

        /// <summary>
        /// Gets a member by email and church.
        /// </summary>
        /// <param name="email">Member email.</param>
        /// <param name="churchId">Church id.</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        Task<Member?> GetByEmailAsync(string email, int churchId);

        /// <summary>
        /// Gets all members of a church.
        /// </summary>
        /// <param name="churchId">Church id.</param>
        /// <returns>List of members of the given church.</returns>
        Task<IReadOnlyList<Member?>> GetByChurchAsync(int churchId);

        /// <summary>
        /// Gets active members of a church.
        /// </summary>
        /// <param name="churchId">Church id.</param>
        /// <returns>List of active members of the given church.</returns>
        Task<IReadOnlyList<Member?>> GetActivesByChurchAsync(int churchId);

        /// <summary>
        /// Gets inactive members of a church.
        /// </summary>
        /// <param name="churchId">Church id.</param>
        /// <returns>List of inactive members of the given church.</returns>
        Task<IReadOnlyList<Member?>> GetInactivesByChurchAsync(int churchId);
    }
}