using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a igrejas.
    /// </summary>
    public class IgrejaService : IIgrejaService
    {
        private readonly IIgrejaRepository _igrejaRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="IgrejaService"/>.
        /// </summary>
        /// <param name="igrejaRepository">Repositório de igrejas.</param>
        /// <param name="mapper">Mapeador de objetos.</param>
        public IgrejaService(IIgrejaRepository igrejaRepository, IMapper mapper)
        {
            _igrejaRepository = igrejaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém uma igreja pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da igreja. Pode ser nulo.</param>
        /// <returns>Um <see cref="IgrejaDTO"/> correspondente ou <c>null</c> se não encontrado.</returns>
        public async Task<IgrejaDTO> GetById(int? id)
        {
            var igrejaEntity = await _igrejaRepository.GetByIdAsync(id);
            return _mapper.Map<IgrejaDTO>(igrejaEntity);
        }

        /// <summary>
        /// Obtém todas as igrejas.
        /// </summary>
        /// <returns>Uma coleção somente de leitura de <see cref="IgrejaDTO"/>.</returns>
        public async Task<IReadOnlyCollection<IgrejaDTO>> GetIgrejasAsync()
        {
            var igrejasEntity = await _igrejaRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<IgrejaDTO>>(igrejasEntity);
        }

        /// <summary>
        /// Adiciona uma nova igreja.
        /// </summary>
        /// <param name="igrejaDTO">Dados da igreja a ser adicionada.</param>
        /// <returns>Uma tarefa assíncrona que representa a operação.</returns>
        public async Task Add(IgrejaDTO igrejaDTO)
        {
            var igrejaEntity = _mapper.Map<Igreja>(igrejaDTO);
            await _igrejaRepository.AddAsync(igrejaEntity);
        }

        /// <summary>
        /// Atualiza os dados de uma igreja existente.
        /// </summary>
        /// <param name="igrejaDTO">Dados da igreja a ser atualizada.</param>
        /// <returns>Uma tarefa assíncrona que representa a operação.</returns>
        public async Task Update(IgrejaDTO igrejaDTO)
        {
            var igrejaEntity = _mapper.Map<Igreja>(igrejaDTO);
            await _igrejaRepository.UpdateAsync(igrejaEntity);
        }

        /// <summary>
        /// Remove uma igreja pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da igreja a ser removida. Pode ser nulo.</param>
        /// <returns>Uma tarefa assíncrona que representa a operação.</returns>
        public async Task Remove(int? id)
        {
            var igrejaEntity = await _igrejaRepository.GetByIdAsync(id);
            if (igrejaEntity is null)
                return;

            await _igrejaRepository.DeleteAsync(igrejaEntity);
        }
    }
}