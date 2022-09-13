using AutoMapper;
using MediatR;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AccountOperations.Queries.GetAccountList
{
    public class GetAuthorListQueryHandler : IRequestHandler<GetAccountListQuery, IEnumerable<GetAccountListQuery>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<IEnumerable<GetAccountListQuery>> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {
            var authors = await _unitOfWork.Account.GetAll();

            var result = _mapper.Map<IEnumerable<Account>, IEnumerable<GetAccountListQuery>>(authors);
            return result;
        }
    }
}