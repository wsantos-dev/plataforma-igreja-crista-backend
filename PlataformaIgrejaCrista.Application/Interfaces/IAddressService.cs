using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Service for address-related operations.
    /// </summary>
    public interface IAddressService
    {
        /// <summary>Gets all addresses.</summary>
        Task<IReadOnlyCollection<AddressDTO>> GetAddressAsync();

        /// <summary>Gets an address by id.</summary>
        /// <param name="id">Address id (nullable).</param>
        /// <returns>The address DTO or default if not found.</returns>
        Task<AddressDTO> GetByIdAsync(int? id);


        /// <summary>Adds a new address.</summary>
        /// <param name="addressDTO">Address data to add.</param>
        Task AddAsync(AddressDTO addressDTO);

        /// <summary>Updates an existing address.</summary>
        /// <param name="addressDTO">Address data to update.</param>
        Task UpdateAsync(AddressDTO addressDTO);

        /// <summary>Removes an address by id.</summary>
        /// <param name="id">Address id (nullable).</param>
        Task RemoveAsync(int? id);
    }
}