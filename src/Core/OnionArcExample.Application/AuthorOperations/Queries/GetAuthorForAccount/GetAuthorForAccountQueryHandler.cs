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

namespace OnionArcExample.Application.AuthorOperations.Queries.GetAuthorForAccount
{
    public class GetAuthorForAccountQueryHandler : IRequestHandler<GetAuthorForAccountQuery, ICollection<AuthorForAccountVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorForAccountQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<ICollection<AuthorForAccountVM>> Handle(GetAuthorForAccountQuery request, CancellationToken cancellationToken)
        {
            var authors = await _unitOfWork.Author.GetAuthorsforAccount(request.Id);
            var result = _mapper.Map<ICollection<Author>, ICollection<AuthorForAccountVM>>(authors);

            return result;
        }
    }
}
