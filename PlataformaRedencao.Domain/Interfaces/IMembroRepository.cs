using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    public interface IMembroRepository : IRepository<Membro>
    {
        Task<Membro?> ObterPorCpfAsync(string cpf, int igrejaId);
        Task<Membro?> ObterPorEmailAsync(string email, int igrejaId);
        Task<IReadOnlyList<Membro>> ObterPorIgrejaAsync(int igrejaId);
        Task<IReadOnlyList<Membro>> ObterAtivosPorIgrejaAsync(int igrejaId);
        Task<IReadOnlyList<Membro>> ObterInativosPorIgrejaAsync(int igrejaId);
    }
}