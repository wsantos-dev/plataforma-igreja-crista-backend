using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class ProfissaoRepository : IProfissaoRepository
    {

        public Task<Profissao> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Profissao>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task AdicionarAsync(Profissao entidade)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Profissao entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Profissao entidade)
        {
            throw new NotImplementedException();
        }

    }
}