using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repository for persistence operations on <see cref="User"/> entities.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="UserRepository"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        public UserRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a user by id.
        /// </summary>
        /// <param name="id">User id (nullable).</param>
        /// <returns>The user or <c>null</c> if not found.</returns>
        public async Task<User?> GetByIdAsync(int? id)
            => await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>Read-only collection of users.</returns>
        public async Task<IReadOnlyCollection<User?>> GetAllAsync()
            => await _context.Users
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Gets a user by email address.
        /// </summary>
        /// <param name="email">User email address.</param>
        /// <returns>The user or <c>null</c> if not found.</returns>
        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.EmailAddress == email);

        /// <summary>
        /// Adds a new user and persists it.
        /// </summary>
        /// <param name="entity">User entity to add.</param>
        /// <returns>The added entity with generated values (e.g. Id).</returns>
        public async Task<User> AddAsync(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Updates an existing user and persists changes.
        /// </summary>
        /// <param name="entity">User entity to update.</param>
        /// <returns>The updated entity.</returns>
        public async Task<User> UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Removes a user and persists the deletion.
        /// </summary>
        /// <param name="entity">User entity to remove.</param>
        /// <returns>The removed entity.</returns>
        public async Task<User> DeleteAsync(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}