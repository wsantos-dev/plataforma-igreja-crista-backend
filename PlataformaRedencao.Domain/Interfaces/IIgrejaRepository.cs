using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    public interface IIgrejaRepository : IRepository<Igreja>
    {
        Task<Igreja?> ObterPorCnpjAsync(string cnpj);
        Task<IEnumerable<Igreja>> ObterPorDenominacaoAsync(string denominacao);

    }
}