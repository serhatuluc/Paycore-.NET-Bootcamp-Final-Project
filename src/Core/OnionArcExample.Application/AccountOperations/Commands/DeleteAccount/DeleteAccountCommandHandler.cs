

using MediatR;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AccountOperations.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Account.GetById(request.Id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Account), request.Id);
            }

            await _unitOfWork.Account.Delete(entity);

            return Unit.Value;
        }
    }
}
