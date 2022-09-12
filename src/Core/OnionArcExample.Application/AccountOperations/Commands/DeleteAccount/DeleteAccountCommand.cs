using MediatR;

namespace OnionArcExample.Application.AccountOperations.Commands.DeleteAccount
{
    public class DeleteAccountCommand:IRequest
    {
        public int Id { get; set; }
    }
}
