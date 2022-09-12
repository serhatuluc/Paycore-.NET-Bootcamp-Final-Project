using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArcExample.Application;
using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.WebAPI
{

    [ApiController]
    [Route("api/nhb/[controller]")]
    public class StoreController : ControllerBase
    {

        private readonly IMediator mediator;

        public StoreController(IMediator mediator) 
        {
            this.mediator = mediator;
        }

        //[HttpGet]
        //[ResponseCache(Duration = 60)]
        //public virtual async Task<IActionResult> GetAll()
        //{
        //    var result = await mediator.Send(new GetAuthorListQuery());
        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }

        //    if (result.Response is null)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(result);
        //}

        //[HttpGet("{id}")]
        //public virtual async Task<IActionResult> GetById(int id)
        //{
        //    var result = await mediator.Send(new GetAuthorDetailQuery { Id = id });
        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }

        //    if (result.Response is null)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(result);
        //}

        //[HttpPost]
        //public virtual async Task<IActionResult> Create([FromBody] CreateAuthorCommand dto)
        //{
        //    var result = await mediator.Send(dto);
        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }

        //    if (result.Response is null)
        //    {
        //        return NoContent();
        //    }

        //    if (result.Success)
        //    {
        //        return StatusCode(201, result);
        //    }
        //    return BadRequest(result);
        //}


        //[HttpPut]
        //public virtual async Task<IActionResult> Update([FromBody] UpdateAuthorCommand dto)
        //{
        //    var result = await mediator.Send(dto);
        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }

        //    if (result.Response is null)
        //    {
        //        return NoContent();
        //    }

        //    if (result.Success)
        //    {
        //        return StatusCode(200, result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpDelete]
        //public virtual async Task<IActionResult> Remove(int id)
        //{
        //    var result = await mediator.Send(new DeleteAuthorCommand { Id = id });
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}

    }
}