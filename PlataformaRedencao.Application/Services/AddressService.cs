using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementation of the service for address-related operations.
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="AddressService"/>.
        /// </summary>
        public AddressService(IAddressRepository enderecoRepository, IMapper mapper)
        {
            _addressRepository = enderecoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        public async Task<IReadOnlyCollection<AddressDTO>> GetAddressAsync()
        {
            var itens = await _addressRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<AddressDTO>>(itens);
        }

        /// <summary>
        /// Gets an address by id.
        /// </summary>
        public async Task<AddressDTO> GetById(int? id)
        {
            var item = await _addressRepository.GetByIdAsync(id);
            return _mapper.Map<AddressDTO>(item);
        }

        /// <summary>
        /// Adds a new address.
        /// </summary>
        public async Task Add(AddressDTO AddressDTO)
        {
            var entity = _mapper.Map<Address>(AddressDTO);
            await _addressRepository.AddAsync(entity);
        }

        /// <summary>
        /// Updates an existing address.
        /// </summary>
        public async Task Update(AddressDTO AddressDTO)
        {
            var entity = _mapper.Map<Address>(AddressDTO);
            await _addressRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// Removes an address by id.
        /// </summary>
        public async Task Remove(int? id)
        {
            var entity = await _addressRepository.GetByIdAsync(id);
            if (entity is null)
                return;

            await _addressRepository.DeleteAsync(entity);
        }
    }
}