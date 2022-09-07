using AutoMapper;
using OnionArcExample.Domain;

namespace OnionArcExample.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
           
            CreateMap<StoreDto, Store>().ReverseMap();
           
            CreateMap<AccountDto, Account>().ReverseMap();
           
        }

    }
}
