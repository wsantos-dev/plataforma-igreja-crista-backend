using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="AssinaturaEletronica"/>.
    /// </summary>
    public class AssinaturaEletronicaRepository : IAssinaturaEletronicaRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="AssinaturaEletronicaRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public AssinaturaEletronicaRepository(PlataformaRedencaoDbContext context)
            => _context = context;

        /// <summary>
        /// Obtém uma assinatura eletrônica pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da assinatura eletrônica.</param>
        /// <returns>A entidade <see cref="AssinaturaEletronica"/> ou <c>null</c> caso não exista.</returns>
        public async Task<AssinaturaEletronica?> ObterPorIdAsync(int? id)
            => await _context.AssinaturaEletronicas
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        /// <summary>
        /// Obtém todas as assinaturas eletrônicas registradas.
        /// </summary>
        /// <returns>Uma coleção de <see cref="AssinaturaEletronica"/> (pode estar vazia).</returns>
        public async Task<IReadOnlyCollection<AssinaturaEletronica?>> ObterTodosAsync()
            => await _context.AssinaturaEletronicas
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Adiciona uma nova assinatura eletrônica e persiste no banco.
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada.</param>
        /// <returns>A entidade adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<AssinaturaEletronica> AdicionarAsync(AssinaturaEletronica entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Atualiza uma assinatura eletrônica existente e persiste as alterações.
        /// </summary>
        /// <param name="entidade">Entidade com as alterações.</param>
        /// <returns>A entidade atualizada.</returns>
        public async Task<AssinaturaEletronica> AtualizarAsync(AssinaturaEletronica entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Remove uma assinatura eletrônica e persiste a exclusão.
        /// </summary>
        /// <param name="entidade">Entidade a ser removida.</param>
        /// <returns>A entidade removida.</returns>
        public async Task<AssinaturaEletronica> Excluir(AssinaturaEletronica entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }
    }
}