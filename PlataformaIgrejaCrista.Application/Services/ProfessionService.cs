using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementation of the service for profession-related operations.
    /// </summary>
    public class ProfessionService : IProfissionService
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="professionService"/>.
        /// </summary>
        public ProfessionService(IProfessionRepository professionRepository, IMapper mapper)
        {
            _professionRepository = professionRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all professions.
        /// </summary>
        public async Task<IReadOnlyCollection<ProfessionDTO>> GetProfessionsAsync()
        {
            var profissoes = await _professionRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<ProfessionDTO>>(profissoes);
        }

        /// <summary>
        /// Gets a profession by id.
        /// </summary>
        public async Task<ProfessionDTO> GetByIdAsync(int? id)
        {
            var profession = await _professionRepository.GetByIdAsync(id);
            return _mapper.Map<ProfessionDTO>(profession);
        }

        ///<summary>
        ///  Gets a profession by name
        /// </summary>
        public async Task<ProfessionDTO> GetByNameAsync(string name)
        {
            var profession = await _professionRepository.GetByNameAsync(name);
            return _mapper.Map<ProfessionDTO>(profession);
        }

        /// <summary>
        /// Adds a new profession.
        /// </summary>
        public async Task<int> AddAsync(ProfessionDTO ProfessionDTO)
        {
            var profession = _mapper.Map<Profession>(ProfessionDTO);
            var entity = await _professionRepository.AddAsync(profession);

            return entity.Id;
        }

        /// <summary>
        /// Updates an existing profession.
        /// </summary>
        public async Task UpdateAsync(ProfessionDTO ProfessionDTO)
        {
            var profession = _mapper.Map<Profession>(ProfessionDTO);
            await _professionRepository.UpdateAsync(profession);
        }

        /// <summary>
        /// Removes a profession by id.
        /// </summary>
        public async Task RemoveAsync(int? id)
        {
            var profession = await _professionRepository.GetByIdAsync(id);
            if (profession is null)
                return;

            await _professionRepository.DeleteAsync(profession);
        }
    }
}