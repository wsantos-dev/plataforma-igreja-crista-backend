using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementation of the service for church-related operations.
    /// </summary>
    public class ChurchService : IChurchService
    {
        private readonly IChurchRepository _churchRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="ChurchService"/>.
        /// </summary>
        /// <param name="churchRepository">Church repository.</param>
        /// <param name="mapper">Object mapper.</param>
        public ChurchService(IChurchRepository churchRepository, IMapper mapper)
        {
            _churchRepository = churchRepository;
            _mapper = mapper;

        }

        /// <summary>
        /// Gets a church by id.
        /// </summary>
        /// <param name="id">Church id (nullable).</param>
        /// <returns>The <see cref="ChurchDTO"/> or <c>null</c> if not found.</returns>
        public async Task<ChurchDTO> GetById(int? id)
        {
            var igrejaEntity = await _churchRepository.GetByIdAsync(id);
            return _mapper.Map<ChurchDTO>(igrejaEntity);
        }

        /// <summary>
        /// Gets all churches.
        /// </summary>
        /// <returns>A read-only collection of <see cref="ChurchDTO"/>.</returns>
        public async Task<IReadOnlyCollection<ChurchDTO>> GetChurchesAsync()
        {
            var igrejasEntity = await _churchRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<ChurchDTO>>(igrejasEntity);
        }

        /// <summary>
        /// Adds a new church.
        /// </summary>
        /// <param name="ChurchDTO">Church data to add.</param>
        /// <returns>A task representing the async operation.</returns>
        public async Task Add(ChurchDTO ChurchDTO)
        {
            var igrejaEntity = _mapper.Map<Church>(ChurchDTO);
            await _churchRepository.AddAsync(igrejaEntity);
        }

        /// <summary>
        /// Updates an existing church.
        /// </summary>
        /// <param name="ChurchDTO">Church data to update.</param>
        /// <returns>A task representing the async operation.</returns>
        public async Task Update(ChurchDTO ChurchDTO)
        {
            var igrejaEntity = _mapper.Map<Church>(ChurchDTO);
            await _churchRepository.UpdateAsync(igrejaEntity);
        }

        /// <summary>
        /// Removes a church by id.
        /// </summary>
        /// <param name="id">Church id to remove (nullable).</param>
        /// <returns>A task representing the async operation.</returns>
        public async Task Remove(int? id)
        {
            var igrejaEntity = await _churchRepository.GetByIdAsync(id);
            if (igrejaEntity is null)
                return;

            await _churchRepository.DeleteAsync(igrejaEntity);
        }
    }
}