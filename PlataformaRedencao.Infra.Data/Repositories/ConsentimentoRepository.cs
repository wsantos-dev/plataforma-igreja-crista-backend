using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="Consentimento"/>.
    /// </summary>
    public class ConsentimentoRepository : IConsentimento
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ConsentimentoRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public ConsentimentoRepository(PlataformaRedencaoDbContext context)
            => _context = context;

        /// <summary>
        /// Obtém um consentimento pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do consentimento.</param>
        /// <returns>A entidade <see cref="Consentimento"/> ou <c>null</c> caso não exista.</returns>
        public async Task<Consentimento?> ObterPorIdAsync(int? id)
            => await _context.Consentimentos
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        /// <summary>
        /// Obtém todos os consentimentos registrados.
        /// </summary>
        /// <returns>Uma coleção de <see cref="Consentimento"/> (pode estar vazia).</returns>
        public async Task<IReadOnlyCollection<Consentimento?>> ObterTodosAsync()
            => await _context.Consentimentos
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Adiciona um novo consentimento e persiste no banco.
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada.</param>
        /// <returns>A entidade adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<Consentimento> AdicionarAsync(Consentimento entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Atualiza um consentimento existente e persiste as alterações.
        /// </summary>
        /// <param name="entidade">Entidade com as alterações.</param>
        /// <returns>A entidade atualizada.</returns>
        public async Task<Consentimento> AtualizarAsync(Consentimento entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Remove um consentimento e persiste a exclusão.
        /// </summary>
        /// <param name="entidade">Entidade a ser removida.</param>
        /// <returns>A entidade removida.</returns>
        public async Task<Consentimento> Excluir(Consentimento entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }
    }
}