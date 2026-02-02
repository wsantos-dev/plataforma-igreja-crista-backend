using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="Endereco"/>.
    /// </summary>
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="EnderecoRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public EnderecoRepository(PlataformaRedencaoDbContext context)
            => _context = context;

        /// <summary>
        /// Obtém um endereço pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do endereço.</param>
        /// <returns>A entidade <see cref="Endereco"/> ou <c>null</c> caso não exista.</returns>
        public Task<Endereco?> GetByIdAsync(int? id)
            => _context.Enderecos
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        /// <summary>
        /// Obtém todos os endereços registrados.
        /// </summary>
        /// <returns>Uma coleção de <see cref="Endereco"/> (pode estar vazia).</returns>
        public async Task<IReadOnlyCollection<Endereco?>> GetAllAsync()
            => await _context.Enderecos
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Adiciona um novo endereço e persiste no banco.
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada.</param>
        /// <returns>A entidade adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<Endereco> AddAsync(Endereco entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }
        /// <summary>
        /// Atualiza um endereço existente e persiste as alterações.
        /// </summary>
        /// <param name="entidade">Entidade com as alterações.</param>
        /// <returns>A entidade atualizada.</returns>
        public async Task<Endereco> UpdateAsync(Endereco entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }
        /// <summary>
        /// Remove um endereço e persiste a exclusão.
        /// </summary>
        /// <param name="entidade">Entidade a ser removida.</param>
        /// <returns>A entidade removida.</returns>
        public async Task<Endereco> DeleteAsync(Endereco entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }
    }
}