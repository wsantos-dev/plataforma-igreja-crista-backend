using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        public UserRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByIdAsync(int? id)
            => await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<IReadOnlyCollection<User?>> GetAllAsync()
            => await _context.Users
            .AsNoTracking()
            .ToListAsync();

        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.EmailAddress == email);

        public async Task<User> AddAsync(User entidade)
        {
            _context.Users.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<User> UpdateAsync(User entidade)
        {
            _context.Users.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<User> DeleteAsync(User entidade)
        {
            _context.Users.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }
    }
}