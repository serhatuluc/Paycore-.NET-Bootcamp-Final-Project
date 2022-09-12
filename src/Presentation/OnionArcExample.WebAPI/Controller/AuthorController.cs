using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcExample.Application.AuthorOperations;
using OnionArcExample.Application.AuthorOperations.Commands.UpdateAuthor;
using OnionArcExample.Application.AuthorOperations.Queries.GetAuthorDetail;
using OnionArcExample.Application.AuthorOperations.Queries.GetAuthorList;
using System.Threading.Tasks;

namespace OnionArcExample.WebAPI
{
    [ApiController]
    [Route("api/nhb/[controller]")]

    public class AuthorController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAuthorListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetAuthorDetailQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Create([FromBody] CreateAuthorCommand dto)
        {
            await mediator.Send(dto);
            return NoContent();
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Update([FromBody] UpdateAuthorCommand dto)
        {
            await mediator.Send(dto);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Remove(int id)
        {
            await mediator.Send(new DeleteAuthorCommand { Id = id });
            return NoContent();
        }
    }
}
