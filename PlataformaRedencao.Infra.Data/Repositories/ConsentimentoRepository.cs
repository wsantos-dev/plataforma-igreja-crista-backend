using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class ConsentimentoRepository : IConsentimento
    {
        public Task<Consentimento> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Consentimento>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task AdicionarAsync(Consentimento entidade)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Consentimento entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Consentimento entidade)
        {
            throw new NotImplementedException();
        }
    }
}