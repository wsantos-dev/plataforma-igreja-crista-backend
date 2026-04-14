using Microsoft.EntityFrameworkCore;
using PlataformaIgrejaCrista.Domain.Entities;
using PlataformaIgrejaCrista.Domain.Interfaces;
using PlataformaIgrejaCrista.Infra.Data.Context;

namespace PlataformaIgrejaCrista.Infra.Data.Repositories
{
    /// <summary>
    /// Repository for persistence operations on <see cref="Address"/> entities.
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly PlataformaIgrejaCristaDbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="AddressRepository"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        public AddressRepository(PlataformaIgrejaCristaDbContext context)
            => _context = context;

        /// <summary>
        /// Gets an address by id.
        /// </summary>
        /// <param name="id">Address id.</param>
        /// <returns>The <see cref="Address"/> entity or <c>null</c> if not found.</returns>
        public Task<Address?> GetByIdAsync(int? id)
            => _context.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        /// <summary>
        /// Gets all registered addresses.
        /// </summary>
        /// <returns>A collection of <see cref="Address"/> (may be empty).</returns>
        public async Task<IReadOnlyCollection<Address?>> GetAllAsync()
            => await _context.Addresses
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Adds a new address and persists it.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>The added entity with generated values (e.g. Id).</returns>
        public async Task<Address> AddAsync(Address entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        /// <summary>
        /// Updates an existing address and persists changes.
        /// </summary>
        /// <param name="entity">Entity with changes.</param>
        /// <returns>The updated entity.</returns>
        public async Task<Address> UpdateAsync(Address entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        /// <summary>
        /// Removes an address and persists the deletion.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        /// <returns>The removed entity.</returns>
        public async Task<Address> DeleteAsync(Address entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}