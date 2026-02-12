namespace PlataformaRedencao.Domain.Interfaces
{
    /// <summary>
    /// Generic repository contract for CRUD operations on domain entities.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets an entity by id.
        /// </summary>
        /// <param name="id">Entity id (nullable).</param>
        /// <returns>The entity or <c>null</c> if not found.</returns>
        Task<T?> GetByIdAsync(int? id);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>Read-only collection of entities.</returns>
        Task<IReadOnlyCollection<T?>> GetAllAsync();

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>The added entity with generated values (e.g. Id).</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity with changes.</param>
        /// <returns>The updated entity.</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        /// <returns>The removed entity.</returns>
        Task<T> DeleteAsync(T entity);
    }
}