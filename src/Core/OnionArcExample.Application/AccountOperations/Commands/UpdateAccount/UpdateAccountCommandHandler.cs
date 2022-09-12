using MediatR;
using OnionArcExample.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AccountOperations.Commands.UpdateAccount
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Account.GetById(request.Id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Domain.Account), request.Id);
            }

            entity.Name = request.Name;
            entity.UserName = request.UserName;

            await _unitOfWork.Account.Update(entity);

            return Unit.Value;
        }
    }
}
