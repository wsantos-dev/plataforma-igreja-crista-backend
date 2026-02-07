using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="Membro"/>.
    /// </summary>
    public class MembroRepository : IMembroRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="MembroRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public MembroRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém um membro pelo identificador.
        /// </summary>
        /// <param name="id">Identificador do membro (pode ser nulo).</param>
        /// <returns>Uma tarefa que contém o membro encontrado ou <c>null</c> se não encontrado.</returns>
        public async Task<Membro?> ObterPorIdAsync(int? id)
            => await _context.Membros
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

        /// <summary>
        /// Obtém os membros de uma igreja.
        /// </summary>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>Uma tarefa que contém a lista de membros da igreja informada.</returns>
        public async Task<IReadOnlyList<Membro>> ObterPorIgrejaAsync(int igrejaId)
            => await _context.Membros
                .AsNoTracking()
                .Where(m => m.IgrejaId == igrejaId)
                .ToListAsync();

        /// <summary>
        /// Obtém todos os membros.
        /// </summary>
        /// <returns>Uma tarefa que contém uma coleção somente-leitura com todos os membros.</returns>
        public async Task<IReadOnlyCollection<Membro?>> ObterTodosAsync()
            => await _context.Membros
                .AsNoTracking()
                .ToListAsync();

        /// <summary>
        /// Adiciona um novo membro e persiste no banco.
        /// </summary>
        /// <param name="entidade">Entidade <see cref="Membro"/> a ser adicionada.</param>
        /// <returns>A entidade adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<Membro> AdicionarAsync(Membro entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Atualiza um membro existente e persiste as alterações.
        /// </summary>
        /// <param name="entidade">Entidade <see cref="Membro"/> a ser atualizada.</param>
        /// <returns>A entidade atualizada.</returns>
        public async Task<Membro> AtualizarAsync(Membro entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Remove um membro e persiste a exclusão.
        /// </summary>
        /// <param name="entidade">Entidade <see cref="Membro"/> a ser removida.</param>
        /// <returns>A entidade removida.</returns>
        public async Task<Membro> Excluir(Membro entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Obtém membros ativos de uma igreja.
        /// </summary>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>Uma tarefa que contém a lista de membros ativos da igreja informada.</returns>
        public async Task<IReadOnlyList<Membro>> ObterAtivosPorIgrejaAsync(int igrejaId)
            => await _context.Membros
                .AsNoTracking()
                .Where(m => m.IgrejaId == igrejaId && m.Situacao == SituacaoMembro.Ativo)
                .ToListAsync();

        /// <summary>
        /// Obtém membros inativos de uma igreja.
        /// </summary>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>Uma tarefa que contém a lista de membros inativos da igreja informada.</returns>
        public async Task<IReadOnlyList<Membro>> ObterInativosPorIgrejaAsync(int igrejaId)
            => await _context.Membros
                .AsNoTracking()
                .Where(m => m.IgrejaId == igrejaId && m.Situacao == SituacaoMembro.Afastado)
                .ToListAsync();

        /// <summary>
        /// Obtém um membro pela combinação CPF e igreja.
        /// </summary>
        /// <param name="cpf">CPF do membro.</param>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>A entidade encontrada ou <c>null</c> caso não exista.</returns>
        public async Task<Membro?> ObterPorCpfAsync(string cpf, int igrejaId)
            => await _context.Membros
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Cpf == cpf && m.IgrejaId == igrejaId);

        /// <summary>
        /// Obtém um membro pelo e-mail e igreja.
        /// </summary>
        /// <param name="email">E-mail do membro.</param>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>A entidade encontrada ou <c>null</c> caso não exista.</returns>
        public async Task<Membro?> ObterPorEmailAsync(string email, int igrejaId)
            => await _context.Membros
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Contato.Email!.Endereco == email && m.IgrejaId == igrejaId);

    }
}