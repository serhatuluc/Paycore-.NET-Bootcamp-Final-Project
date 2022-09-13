using MediatR;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Author.GetById(request.Id);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;

            await _unitOfWork.Author.Update(entity);

            return Unit.Value;
        }
    }
}
