using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Church, ChurchDTO>().ReverseMap();
            CreateMap<Profession, ProfessionDTO>().ReverseMap();
        }

    }
}