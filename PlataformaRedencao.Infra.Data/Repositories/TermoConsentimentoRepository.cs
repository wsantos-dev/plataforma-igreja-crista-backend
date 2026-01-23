using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class TermoConsentimentoRepository : ITermoConsentimentoRepository
    {
        public Task<TermoConsentimento> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<TermoConsentimento>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task AdicionarAsync(TermoConsentimento entidade)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(TermoConsentimento entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(TermoConsentimento entidade)
        {
            throw new NotImplementedException();
        }
    }
}