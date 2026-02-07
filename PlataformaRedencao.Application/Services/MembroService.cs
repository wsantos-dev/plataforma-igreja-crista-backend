using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a membros.
    /// </summary>
    public class MembroService : IMembroService
    {
        private readonly IMembroRepository _membroRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="MembroService"/>.
        /// </summary>
        public MembroService(IMembroRepository membroRepository, IMapper mapper)
        {
            _membroRepository = membroRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os membros.
        /// </summary>
        public async Task<IReadOnlyCollection<MembroDTO>> GetMembrosAsync()
        {
            var membros = await _membroRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<MembroDTO>>(membros);
        }

        /// <summary>
        /// Obtém um membro pelo identificador.
        /// </summary>
        public async Task<MembroDTO> GetById(int? id)
        {
            var membro = await _membroRepository.GetByIdAsync(id);
            return _mapper.Map<MembroDTO>(membro);
        }

        /// <summary>
        /// Obtém um membro pelo CPF dentro de uma igreja.
        /// </summary>
        public async Task<MembroDTO> GetByCpfAsync(string cpf, int igrejaId)
        {
            var membro = await _membroRepository.ObterPorCpfAsync(cpf, igrejaId);
            return _mapper.Map<MembroDTO>(membro);
        }

        /// <summary>
        /// Obtém um membro pelo e-mail dentro de uma igreja.
        /// </summary>
        public async Task<MembroDTO> GetByEmailAsync(string email, int igrejaId)
        {
            var membro = await _membroRepository.ObterPorEmailAsync(email, igrejaId);
            return _mapper.Map<MembroDTO>(membro);
        }

        /// <summary>
        /// Obtém os membros de uma igreja.
        /// </summary>
        public async Task<IReadOnlyList<MembroDTO>> GetByIgrejaAsync(int igrejaId)
        {
            var membros = await _membroRepository.ObterPorIgrejaAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MembroDTO>>(membros);
        }

        /// <summary>
        /// Obtém membros ativos de uma igreja.
        /// </summary>
        public async Task<IReadOnlyList<MembroDTO>> GetAtivosByIgrejaAsync(int igrejaId)
        {
            var membros = await _membroRepository.ObterAtivosPorIgrejaAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MembroDTO>>(membros);
        }

        /// <summary>
        /// Obtém membros inativos de uma igreja.
        /// </summary>
        public async Task<IReadOnlyList<MembroDTO>> GetInativosByIgrejaAsync(int igrejaId)
        {
            var membros = await _membroRepository.ObterInativosPorIgrejaAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MembroDTO>>(membros);
        }

        /// <summary>
        /// Adiciona um novo membro.
        /// </summary>
        public async Task Add(MembroDTO membroDTO)
        {
            var membro = _mapper.Map<Membro>(membroDTO);
            await _membroRepository.AddAsync(membro);
        }

        /// <summary>
        /// Atualiza os dados de um membro existente.
        /// </summary>
        public async Task Update(MembroDTO membroDTO)
        {
            var membro = _mapper.Map<Membro>(membroDTO);
            await _membroRepository.UpdateAsync(membro);
        }

        /// <summary>
        /// Remove um membro pelo identificador.
        /// </summary>
        public async Task Remove(int? id)
        {
            var membro = await _membroRepository.GetByIdAsync(id);
            if (membro is null)
                return;

            await _membroRepository.DeleteAsync(membro);
        }
    }
}