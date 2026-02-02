using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    public interface IIgrejaService
    {
        Task<IReadOnlyCollection<IgrejaDTO>> GetIgrejasAsync();
        Task<IgrejaDTO> GetById(int? id);
    }
}