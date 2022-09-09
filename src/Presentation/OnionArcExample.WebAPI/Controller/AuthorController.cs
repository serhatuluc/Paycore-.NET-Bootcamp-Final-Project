using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionArcExample.Application;
using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.WebAPI
{
    [ApiController]
    [Route("api/nhb/[controller]")]

    public class AuthorController : BaseController<AuthorDto,Author>
    {

        private readonly IAuthorService authorService;


        public AuthorController(IAuthorService authorService, IMapper mapper) : base(authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet("getaccount")]
        public virtual async Task<IActionResult> GetAccount(int id)
        {
            var result = await authorService.GetAccountById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
