using AutoMapper;
using OnionArcExample.Application.AccountOperations.Queries.GetAccountList;
using OnionArcExample.Application.AuthorOperations.Queries.GetAuthorList;
using OnionArcExample.Domain;

namespace OnionArcExample.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, GetAuthorListQuery>().ReverseMap();
           
            CreateMap<Account, GetAccountListQuery>().ReverseMap();

        }

    }
}
