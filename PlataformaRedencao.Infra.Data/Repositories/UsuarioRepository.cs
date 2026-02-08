using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PlataformaRedencaoDbContext _context;

        public UsuarioRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByIdAsync(int? id)
            => await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<IReadOnlyCollection<Usuario?>> GetAllAsync()
            => await _context.Usuarios
            .AsNoTracking()
            .ToListAsync();

        public async Task<Usuario?> GetByEmailAsync(string email)
            => await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);

        public async Task<Usuario> AddAsync(Usuario entidade)
        {
            _context.Usuarios.Add(entidade);
            await _context.SaveChangesAsync();
            
            return entidade;
        }

        public async Task<Usuario> UpdateAsync(Usuario entidade)
        {
            _context.Usuarios.Update(entidade);
            await _context.SaveChangesAsync();
            
            return entidade;
        }

        public async Task<Usuario> DeleteAsync(Usuario entidade)
        {
            _context.Usuarios.Remove(entidade);
            await _context.SaveChangesAsync();
            
            return entidade;
        }
    }
}