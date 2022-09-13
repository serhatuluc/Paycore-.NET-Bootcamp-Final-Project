using AutoMapper;
using MediatR;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations.Queries.GetAuthorList
{
    public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery,IEnumerable<GetAuthorListQuery>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
     

        public async Task<IEnumerable<GetAuthorListQuery>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            var authors = await _unitOfWork.Author.GetAll();
           
            var result = _mapper.Map<IEnumerable<Author>,IEnumerable<GetAuthorListQuery>>(authors);
           return result;
        }
    }
}
