using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionArcExample.Application;
using OnionArcExample.Domain;

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
    }
}
