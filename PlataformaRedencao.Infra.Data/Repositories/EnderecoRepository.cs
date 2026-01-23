using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public Task<Endereco> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Endereco>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
        public Task AdicionarAsync(Endereco entidade)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Endereco entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Endereco entidade)
        {
            throw new NotImplementedException();
        }
    }
}