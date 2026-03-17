using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.Exceptions;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Domain.Messages;


namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementation of the service for member-related operations.
    /// </summary>
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _membroRepository;
        private readonly IChurchRepository _churchRepository;
        private readonly IProfessionRepository _professionRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="MemberService"/>.
        /// </summary>
        public MemberService(
            IMemberRepository membroRepository,
            IChurchRepository churchRepository,
            IProfessionRepository professionRepository,
            IAddressRepository addressRepository,
            IMapper mapper)
        {
            _membroRepository = membroRepository;
            _churchRepository = churchRepository;
            _professionRepository = professionRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all members.
        /// </summary>
        public async Task<IReadOnlyCollection<MemberDTO>> GetMembersAsync()
        {
            var membros = await _membroRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<MemberDTO>>(membros);
        }

        /// <summary>
        /// Gets a member by id.
        /// </summary>
        public async Task<MemberDTO> GetByIdAsync(int? id)
        {
            var membro = await _membroRepository.GetByIdAsync(id);
            return _mapper.Map<MemberDTO>(membro);
        }

        /// <summary>
        /// Gets a member by CPF within a church.
        /// </summary>
        public async Task<MemberDTO> GetByCpfAsync(string cpf, int igrejaId)
        {
            var membro = await _membroRepository.GetByCpfAsync(cpf, igrejaId);
            return _mapper.Map<MemberDTO>(membro);
        }

        /// <summary>
        /// Gets a member by email within a church.
        /// </summary>
        public async Task<MemberDTO> GetByEmailAsync(string email, int igrejaId)
        {
            var membro = await _membroRepository.GetByEmailAsync(email, igrejaId);
            return _mapper.Map<MemberDTO>(membro);
        }

        /// <summary>
        /// Gets members of a church.
        /// </summary>
        public async Task<IReadOnlyList<MemberDTO>> GetByChurchAsync(int igrejaId)
        {
            var membros = await _membroRepository.GetByChurchAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MemberDTO>>(membros);
        }

        /// <summary>
        /// Gets active members of a church.
        /// </summary>
        public async Task<IReadOnlyList<MemberDTO>> GetActivesByIgrejaAsync(int igrejaId)
        {
            var membros = await _membroRepository.GetActivesByChurchAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MemberDTO>>(membros);
        }

        /// <summary>
        /// Gets inactive members of a church.
        /// </summary>
        public async Task<IReadOnlyList<MemberDTO>> GetInactivesByIgrejaAsync(int igrejaId)
        {
            var membros = await _membroRepository.GetInactivesByChurchAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MemberDTO>>(membros);
        }

        /// <summary>
        /// Adds a new member.
        /// </summary>
        public async Task AddAsync(MemberDTO MemberDTO)
        {
            var membro = _mapper.Map<Member>(MemberDTO);
            await _membroRepository.AddAsync(membro);
        }

        /// <summary>
        /// Updates an existing member.
        /// </summary>
        public async Task UpdateAsync(MemberDTO MemberDTO)
        {
            var membro = _mapper.Map<Member>(MemberDTO);
            await _membroRepository.UpdateAsync(membro);
        }

        /// <summary>
        /// Removes a member by id.
        /// </summary>
        public async Task RemoveAsync(int? id)
        {
            var membro = await _membroRepository.GetByIdAsync(id);
            if (membro is null)
                return;

            await _membroRepository.DeleteAsync(membro);
        }

        public async Task<int> CreateAsync(
            CreateMemberRequestDTO request,
            string applicationUserId)
        {
            await ValidateCpfAsync(request.Cpf!, request.ChurchId);

            var (church, profession) =
                await ResolveDependenciesAsync(request.ChurchId, request.ProfessionId);

            var address = await CreateAddressAsync(request);

            var creationData = new MemberCreationData(
                request.Cpf!,
                request.FirstName!,
                request.LastName!,
                request.Email!,
                request.Phone,
                request.BirthDate,
                request.Gender,
                request.AdmissionDate,
                (MemberAdmissionType)request.AdmissionType
            );

            var member = Member.Create(
                creationData,
                address,
                profession,
                church
            );

            await _membroRepository.AddAsync(member);

            return member.Id;

        }

        private async Task<Address> CreateAddressAsync(CreateMemberRequestDTO request)
        {
            var address = new Address(
                entityId: 0,
                entityType: EntityAddressType.Member,
                street: request.Address!.Street!,
                complement: request.Address.Complement!,
                number: request.Address.Number!,
                city: request.Address.City!,
                state: request.Address.State!,
                country: request.Address.Country!,
                postalCode: request.Address.PostalCode!
            );

            await _addressRepository.AddAsync(address);

            return address;
        }



        private async Task<(Church church, Profession profession)> ResolveDependenciesAsync(
            int churchId, int professionId)
        {
            var church = await _churchRepository.GetByIdAsync(churchId);

            if (church is null)
                throw new ChurchNotFoundException("CHURCH_NOT_FOUND", ErrorMessages.ChurchNotFound);

            var profession = await _professionRepository.GetByIdAsync(professionId);

            if (profession is null)
                throw new ProfessionalNotFoundException("PROFESSIONAL_NOT_FOUND", ErrorMessages.ProfessionalNotFound);

            return (church, profession);
        }

        private async Task ValidateCpfAsync(string cpf, int churchId)
        {
            var existing = await _membroRepository
                .GetByCpfAsync(cpf, churchId);

            if (existing is not null)
                throw new InvalidCpfException();
        }
    }
}