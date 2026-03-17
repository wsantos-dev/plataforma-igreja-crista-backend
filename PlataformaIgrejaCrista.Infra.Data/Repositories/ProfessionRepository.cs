using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repository for persistence operations on <see cref="Profession"/> entities.
    /// </summary>
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="ProfessionRepository"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        public ProfessionRepository(PlataformaRedencaoDbContext context)
            => _context = context;

        /// <summary>
        /// Gets a profession by id.
        /// </summary>
        /// <param name="id">Profession id.</param>
        /// <returns>The <see cref="Profession"/> entity or <c>null</c> if not found.</returns>
        public async Task<Profession?> GetByIdAsync(int? id)
            => await _context.Professions
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);


        public async Task<Profession?> GetByNameAsync(string? name)
            => await _context.Professions
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Term == name);

        /// <summary>
        /// Gets all registered professions.
        /// </summary>
        /// <returns>A collection of <see cref="Profession"/> (may be empty).</returns>
        public async Task<IReadOnlyCollection<Profession?>> GetAllAsync()
            => await _context.Professions
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Adds a new profession and persists it.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>The added entity with generated values (e.g. Id).</returns>
        public async Task<Profession> AddAsync(Profession entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Updates an existing profession and persists changes.
        /// </summary>
        /// <param name="entity">Entity with changes.</param>
        /// <returns>The updated entity.</returns>
        public async Task<Profession> UpdateAsync(Profession entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Removes a profession and persists the deletion.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        /// <returns>The removed entity.</returns>
        public async Task<Profession> DeleteAsync(Profession entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}