using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class IgrejaRepository : IIgrejaRepository
    {
        public Task<Igreja> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Igreja>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task AdicionarAsync(Igreja entidade)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Igreja entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Igreja entidade)
        {
            throw new NotImplementedException();
        }

        public Task<Igreja?> ObterPorCnpjAsync(string cnpj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Igreja>> ObterPorDenominacaoAsync(string denominacao)
        {
            throw new NotImplementedException();
        }
    }
}