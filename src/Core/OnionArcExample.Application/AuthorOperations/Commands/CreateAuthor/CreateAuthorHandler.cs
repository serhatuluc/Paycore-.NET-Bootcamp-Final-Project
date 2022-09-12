using MediatR;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthorHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Author()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Account =  request.Account
            };

           await _unitOfWork.Author.Create(entity);
            return Unit.Value;
        }
    }
}
