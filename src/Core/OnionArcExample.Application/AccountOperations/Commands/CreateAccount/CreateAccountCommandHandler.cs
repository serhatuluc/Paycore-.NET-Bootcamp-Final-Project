using MediatR;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AccountOperations.Commands.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = new Account()
            {
                Name = request.Name,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                Role = "Viewer",
                LastActivity = DateTime.UtcNow
                
            };

            await _unitOfWork.Account.Create(entity);
            
            return Unit.Value;
        }
    }
}
