using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="Profissao"/>.
    /// </summary>
    public class ProfissaoRepository : IProfissaoRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProfissaoRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public ProfissaoRepository(PlataformaRedencaoDbContext context)
            => _context = context;

        /// <summary>
        /// Obtém uma profissão pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da profissão.</param>
        /// <returns>A entidade <see cref="Profissao"/> ou <c>null</c> caso não exista.</returns>
        public async Task<Profissao?> GetByIdAsync(int? id)
            => await _context.Profissoes
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        /// <summary>
        /// Obtém todas as profissões registradas.
        /// </summary>
        /// <returns>Uma coleção de <see cref="Profissao"/> (pode estar vazia).</returns>
        public async Task<IReadOnlyCollection<Profissao?>> GetAllAsync()
            => await _context.Profissoes
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Adiciona uma nova profissão e persiste no banco.
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada.</param>
        /// <returns>A entidade adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<Profissao> AddAsync(Profissao entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Atualiza uma profissão existente e persiste as alterações.
        /// </summary>
        /// <param name="entidade">Entidade com as alterações.</param>
        /// <returns>A entidade atualizada.</returns>
        public async Task<Profissao> UpdateAsync(Profissao entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Remove uma profissão e persiste a exclusão.
        /// </summary>
        /// <param name="entidade">Entidade a ser removida.</param>
        /// <returns>A entidade removida.</returns>
        public async Task<Profissao> DeleteAsync(Profissao entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

    }
}