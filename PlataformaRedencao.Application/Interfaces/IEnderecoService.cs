using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Serviço para operações relacionadas a endereços.
    /// </summary>
    public interface IEnderecoService
    {
        /// <summary>
        /// Obtém todos os endereços.
        /// </summary>
        Task<IReadOnlyCollection<EnderecoDTO>> GetEnderecosAsync();

        /// <summary>
        /// Obtém um endereço pelo identificador.
        /// </summary>
        Task<EnderecoDTO> GetById(int? id);

        /// <summary>
        /// Adiciona um novo endereço.
        /// </summary>
        Task Add(EnderecoDTO enderecoDTO);

        /// <summary>
        /// Atualiza um endereço existente.
        /// </summary>
        Task Update(EnderecoDTO enderecoDTO);

        /// <summary>
        /// Remove um endereço pelo identificador.
        /// </summary>
        Task Remove(int? id);
    }
}