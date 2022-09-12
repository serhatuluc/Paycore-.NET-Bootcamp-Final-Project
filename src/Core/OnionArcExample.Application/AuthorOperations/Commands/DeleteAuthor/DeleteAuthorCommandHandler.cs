using MediatR;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
      
        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
           var entity = await _unitOfWork.Author.GetById(request.Id);

            if(entity is null)
            {
               throw new NotFoundException(nameof(Author),request.Id);
            }

            await _unitOfWork.Author.Delete(entity);

            return Unit.Value;
        }
    }
}
