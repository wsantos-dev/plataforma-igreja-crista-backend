using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    public class MembroRepository : IMembroRepository
    {
        public Task<Membro> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Membro>> ObterPorIgrejaAsync(int igrejaId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Membro>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task AdicionarAsync(Membro entidade)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Membro entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Membro entidade)
        {
            throw new NotImplementedException();
        }


        public Task<IReadOnlyList<Membro>> ObterAtivosPorIgrejaAsync(int igrejaId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Membro>> ObterInativosPorIgrejaAsync(int igrejaId)
        {
            throw new NotImplementedException();
        }

        public Task<Membro?> ObterPorCpfAsync(string cpf, int igrejaId)
        {
            throw new NotImplementedException();
        }

        public Task<Membro?> ObterPorEmailAsync(string email, int igrejaId)
        {
            throw new NotImplementedException();
        }

    }
}