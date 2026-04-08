using Microsoft.EntityFrameworkCore;
using PlataformaIgrejaCrista.Domain.Entities;
using PlataformaIgrejaCrista.Domain.Interfaces;
using PlataformaIgrejaCrista.Infra.Data.Context;

namespace PlataformaIgrejaCrista.Infra.Data.Repositories
{
    /// <summary>
    /// Repository for persistence operations on <see cref="Church"/> entities.
    /// </summary>
    public class ChurchRepository : IChurchRepository
    {
        private readonly PlataformaIgrejaCristaDbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="ChurchRepository"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        public ChurchRepository(PlataformaIgrejaCristaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a church by id.
        /// </summary>
        /// <param name="id">Church id (nullable).</param>
        /// <returns>The <see cref="Church"/> entity or <c>null</c> if not found.</returns>
        public async Task<Church?> GetByIdAsync(int? id)
            => await _context.Churches
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);

        /// <summary>
        /// Gets all churches.
        /// </summary>
        /// <returns>A read-only collection of churches.</returns>
        public async Task<IReadOnlyCollection<Church?>> GetAllAsync()
            => await _context.Churches
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Gets a church by CNPJ.
        /// </summary>
        /// <param name="cnpj">Church CNPJ.</param>
        /// <returns>The <see cref="Church"/> entity or <c>null</c> if not found.</returns>
        public async Task<Church?> GetByCnpjAsync(string cnpj)
            => await _context.Churches
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Cnpj == cnpj);

        /// <summary>
        /// Gets churches by denomination.
        /// </summary>
        /// <param name="demomination">Denomination to search for.</param>
        /// <returns>Churches matching the given denomination.</returns>
        public async Task<IEnumerable<Church>> GetByDenominationAsync(string demomination)
            => await _context.Churches
            .AsNoTracking()
            .Where(i => i.Denomination == demomination)
            .ToListAsync();

        /// <summary>
        /// Adds a new church and persists it.
        /// </summary>
        /// <param name="entity">Church entity to add.</param>
        /// <returns>The added entity with generated values (e.g. Id).</returns>
        public async Task<Church> AddAsync(Church entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Updates an existing church and persists changes.
        /// </summary>
        /// <param name="entity">Church entity to update.</param>
        /// <returns>The updated entity.</returns>
        public async Task<Church> UpdateAsync(Church entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Removes a church and persists the deletion.
        /// </summary>
        /// <param name="entity">Church entity to remove.</param>
        /// <returns>The removed entity.</returns>
        public async Task<Church> DeleteAsync(Church entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}