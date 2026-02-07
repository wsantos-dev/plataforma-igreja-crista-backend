using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="Igreja"/>.
    /// </summary>
    public class IgrejaRepository : IIgrejaRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="IgrejaRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public IgrejaRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém uma igreja pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da igreja (pode ser nulo).</param>
        /// <returns>A entidade <see cref="Igreja"/> ou <c>null</c> caso não exista.</returns>
        public async Task<Igreja?> ObterPorIdAsync(int? id)
            => await _context.Igrejas
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);

        /// <summary>
        /// Obtém todas as igrejas.
        /// </summary>
        /// <returns>Uma coleção somente-leitura com todas as igrejas.</returns>
        public async Task<IReadOnlyCollection<Igreja?>> ObterTodosAsync()
            => await _context.Igrejas
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Obtém uma igreja pelo CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ da igreja.</param>
        /// <returns>A entidade <see cref="Igreja"/> ou <c>null</c> caso não exista.</returns>
        public async Task<Igreja?> ObterPorCnpjAsync(string cnpj)
            => await _context.Igrejas
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Cnpj == cnpj);

        /// <summary>
        /// Obtém igrejas pela denominação.
        /// </summary>
        /// <param name="denominacao">Denominação a ser pesquisada.</param>
        /// <returns>As igrejas que correspondem à denominação informada.</returns>
        public async Task<IEnumerable<Igreja>> ObterPorDenominacaoAsync(string denominacao)
            => await _context.Igrejas
            .AsNoTracking()
            .Where(i => i.Denominacao == denominacao)
            .ToListAsync();

        /// <summary>
        /// Adiciona uma nova igreja e persiste no banco.
        /// </summary>
        /// <param name="entidade">Entidade <see cref="Igreja"/> a ser adicionada.</param>
        /// <returns>A entidade adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<Igreja> AdicionarAsync(Igreja entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Atualiza uma igreja existente e persiste as alterações.
        /// </summary>
        /// <param name="entidade">Entidade <see cref="Igreja"/> a ser atualizada.</param>
        /// <returns>A entidade atualizada.</returns>
        public async Task<Igreja> AtualizarAsync(Igreja entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Remove uma igreja e persiste a exclusão.
        /// </summary>
        /// <param name="entidade">Entidade <see cref="Igreja"/> a ser removida.</param>
        /// <returns>A entidade removida.</returns>
        public async Task<Igreja> Excluir(Igreja entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }
    }
}