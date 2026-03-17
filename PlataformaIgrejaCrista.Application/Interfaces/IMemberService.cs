using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Service for member-related operations.
    /// </summary>
    public interface IMemberService
    {
        /// <summary>
        /// Creates a new member in the system.
        /// </summary>
        /// <param name="request">
        /// The request object containing the data required to create the member.
        /// </param>
        /// <param name="applicationUserId">
        /// The identifier of the application user responsible for the operation.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The result contains the identifier of the newly created member.
        /// </returns>
        Task<int> CreateAsync(CreateMemberRequestDTO request, string applicationUserId);

        /// <summary>Gets all members.</summary>
        /// <returns>A read-only collection of <see cref="MemberDTO"/>.</returns>
        Task<IReadOnlyCollection<MemberDTO>> GetMembersAsync();

        /// <summary>Gets a member by id.</summary>
        /// <param name="id">Member id (nullable).</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        Task<MemberDTO> GetByIdAsync(int? id);

        /// <summary>Gets a member by CPF within a church.</summary>
        /// <param name="cpf">Member CPF.</param>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        Task<MemberDTO> GetByCpfAsync(string cpf, int igrejaId);

        /// <summary>Gets a member by email within a church.</summary>
        /// <param name="email">Member email.</param>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        Task<MemberDTO> GetByEmailAsync(string email, int igrejaId);

        /// <summary>Gets members of a church.</summary>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>List of members linked to the church.</returns>
        Task<IReadOnlyList<MemberDTO>> GetByChurchAsync(int igrejaId);

        /// <summary>Gets active members of a church.</summary>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>List of active members linked to the church.</returns>
        Task<IReadOnlyList<MemberDTO>> GetActivesByIgrejaAsync(int igrejaId);

        /// <summary>Gets inactive members of a church.</summary>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>List of inactive members linked to the church.</returns>
        Task<IReadOnlyList<MemberDTO>> GetInactivesByIgrejaAsync(int igrejaId);

        /// <summary>Adds a new member.</summary>
        /// <param name="MemberDTO">Member data to add.</param>
        Task AddAsync(MemberDTO MemberDTO);

        /// <summary>Updates an existing member.</summary>
        /// <param name="MemberDTO">Member data to update.</param>
        Task UpdateAsync(MemberDTO MemberDTO);

        /// <summary>Removes a member by id.</summary>
        /// <param name="id">Member id to remove (nullable).</param>
        Task RemoveAsync(int? id);
    }
}