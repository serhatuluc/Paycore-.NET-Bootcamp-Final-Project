using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcExample.Application.AccountOperations.Commands.CreateAccount;
using OnionArcExample.Application.AccountOperations.Commands.DeleteAccount;
using OnionArcExample.Application.AccountOperations.Commands.UpdateAccount;
using OnionArcExample.Application.AccountOperations.Queries.GetAccountDetail;
using OnionArcExample.Application.AccountOperations.Queries.GetAccountList;
using System.Threading.Tasks;

namespace OnionArcExample.WebAPI
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class AccountContoller : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountContoller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAccountListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetAccountDetailQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Create([FromBody] CreateAccountCommand dto)
        {
            await mediator.Send(dto);
            return NoContent();
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Update([FromBody] UpdateAccountCommand dto)
        {
            await mediator.Send(dto);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Remove(int id)
        {
            await mediator.Send(new DeleteAccountCommand { Id = id });
            return NoContent();
        }
    }
}
