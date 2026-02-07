using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a profissões.
    /// </summary>
    public class ProfissaoService : IProfissaoService
    {
        private readonly IProfissaoRepository _profissaoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProfissaoService"/>.
        /// </summary>
        public ProfissaoService(IProfissaoRepository profissaoRepository, IMapper mapper)
        {
            _profissaoRepository = profissaoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todas as profissões.
        /// </summary>
        public async Task<IReadOnlyCollection<ProfissaoDTO>> GetProfissoesAsync()
        {
            var profissoes = await _profissaoRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<ProfissaoDTO>>(profissoes);
        }

        /// <summary>
        /// Obtém uma profissão pelo identificador.
        /// </summary>
        public async Task<ProfissaoDTO> GetById(int? id)
        {
            var profissao = await _profissaoRepository.GetByIdAsync(id);
            return _mapper.Map<ProfissaoDTO>(profissao);
        }

        /// <summary>
        /// Adiciona uma nova profissão.
        /// </summary>
        public async Task Add(ProfissaoDTO profissaoDTO)
        {
            var profissao = _mapper.Map<Profissao>(profissaoDTO);
            await _profissaoRepository.AddAsync(profissao);
        }

        /// <summary>
        /// Atualiza uma profissão existente.
        /// </summary>
        public async Task Update(ProfissaoDTO profissaoDTO)
        {
            var profissao = _mapper.Map<Profissao>(profissaoDTO);
            await _profissaoRepository.UpdateAsync(profissao);
        }

        /// <summary>
        /// Remove uma profissão pelo identificador.
        /// </summary>
        public async Task Remove(int? id)
        {
            var profissao = await _profissaoRepository.GetByIdAsync(id);
            if (profissao is null)
                return;

            await _profissaoRepository.DeleteAsync(profissao);
        }
    }
}