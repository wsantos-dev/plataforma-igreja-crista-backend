using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Service for profession-related operations.
    /// </summary>
    public interface IProfissionService
    {
        /// <summary>Gets all professions.</summary>
        Task<IReadOnlyCollection<ProfessionDTO>> GetProfessionsAsync();

        /// <summary>Gets a profession by id.</summary>
        Task<ProfessionDTO> GetByIdAsync(int? id);

        Task<ProfessionDTO> GetByNameAsync(string name);

        /// <summary>Adds a new profession.</summary>
        Task<int> AddAsync(ProfessionDTO ProfessionDTO);

        /// <summary>Updates an existing profession.</summary>
        Task UpdateAsync(ProfessionDTO ProfessionDTO);

        /// <summary>Removes a profession by id.</summary>
        Task RemoveAsync(int? id);
    }
}