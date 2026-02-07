using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Serviço para operações relacionadas a profissões.
    /// </summary>
    public interface IProfissaoService
    {
        /// <summary>
        /// Obtém todas as profissões.
        /// </summary>
        Task<IReadOnlyCollection<ProfissaoDTO>> GetProfissoesAsync();

        /// <summary>
        /// Obtém uma profissão pelo identificador.
        /// </summary>
        Task<ProfissaoDTO> GetById(int? id);

        /// <summary>
        /// Adiciona uma nova profissão.
        /// </summary>
        Task Add(ProfissaoDTO profissaoDTO);

        /// <summary>
        /// Atualiza uma profissão existente.
        /// </summary>
        Task Update(ProfissaoDTO profissaoDTO);

        /// <summary>
        /// Remove uma profissão pelo identificador.
        /// </summary>
        Task Remove(int? id);
    }
}