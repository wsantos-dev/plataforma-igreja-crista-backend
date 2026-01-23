using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class AssinaturaEletronicaRepository : IAssinaturaEletronicaRepository
    {
        public Task<AssinaturaEletronica> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<AssinaturaEletronica>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task AdicionarAsync(AssinaturaEletronica entidade)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(AssinaturaEletronica entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(AssinaturaEletronica entidade)
        {
            throw new NotImplementedException();
        }

    }
}