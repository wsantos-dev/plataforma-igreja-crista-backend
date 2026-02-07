using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a endereços.
    /// </summary>
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="EnderecoService"/>.
        /// </summary>
        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os endereços.
        /// </summary>
        public async Task<IReadOnlyCollection<EnderecoDTO>> GetEnderecosAsync()
        {
            var itens = await _enderecoRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<EnderecoDTO>>(itens);
        }

        /// <summary>
        /// Obtém um endereço pelo identificador.
        /// </summary>
        public async Task<EnderecoDTO> GetById(int? id)
        {
            var item = await _enderecoRepository.GetByIdAsync(id);
            return _mapper.Map<EnderecoDTO>(item);
        }

        /// <summary>
        /// Adiciona um novo endereço.
        /// </summary>
        public async Task Add(EnderecoDTO enderecoDTO)
        {
            var entidade = _mapper.Map<Endereco>(enderecoDTO);
            await _enderecoRepository.AddAsync(entidade);
        }

        /// <summary>
        /// Atualiza um endereço existente.
        /// </summary>
        public async Task Update(EnderecoDTO enderecoDTO)
        {
            var entidade = _mapper.Map<Endereco>(enderecoDTO);
            await _enderecoRepository.UpdateAsync(entidade);
        }

        /// <summary>
        /// Remove um endereço pelo identificador.
        /// </summary>
        public async Task Remove(int? id)
        {
            var entidade = await _enderecoRepository.GetByIdAsync(id);
            if (entidade is null)
                return;

            await _enderecoRepository.DeleteAsync(entidade);
        }
    }
}