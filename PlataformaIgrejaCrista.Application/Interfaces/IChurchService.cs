using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Service for church-related operations.
    /// </summary>
    public interface IChurchService
    {
        /// <summary>Gets all churches.</summary>
        /// <returns>A read-only collection of <see cref="ChurchDTO"/>.</returns>
        Task<IReadOnlyCollection<ChurchDTO>> GetChurchesAsync();

        /// <summary>Gets a church by id.</summary>
        /// <param name="id">Church id (nullable).</param>
        /// <returns>The church or <c>null</c> if not found.</returns>
        Task<ChurchDTO> GetById(int? id);

        /// <summary>Adds a new church.</summary>
        /// <param name="ChurchDTO">Church data to add.</param>
        /// <returns>A task representing the async operation.</returns>
        Task Add(ChurchDTO ChurchDTO);

        /// <summary>Updates an existing church.</summary>
        /// <param name="ChurchDTO">Church data to update.</param>
        /// <returns>A task representing the async operation.</returns>
        Task Update(ChurchDTO ChurchDTO);

        /// <summary>Removes a church by id.</summary>
        /// <param name="id">Church id to remove (nullable).</param>
        /// <returns>A task representing the async operation.</returns>
        Task Remove(int? id);
    }
}