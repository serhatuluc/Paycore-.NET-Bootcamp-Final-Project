using MediatR;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AccountOperations.Queries.GetAccountDetail
{
    public class GetAuthorDetailQueryHandler : IRequestHandler<GetAccountDetailQuery, AccountDetailVm>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAuthorDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<AccountDetailVm> Handle(GetAccountDetailQuery request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork.Account.GetById(request.Id);
            if (entity is null)
            {
                throw new NotFoundException(nameof(Account), request.Id);
            }
            var result = new AccountDetailVm()
            {
                Id = entity.Id,
                Name = entity.Name,
                UserName = entity.UserName,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role,
                LastActivity = entity.LastActivity
            };
            return result;
        }
    }
}
