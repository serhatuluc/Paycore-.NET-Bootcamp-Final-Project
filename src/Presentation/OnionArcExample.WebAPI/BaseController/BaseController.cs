using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.WebAPI
{   
    [ApiController]
    public class BaseController<Dto, Entity> : ControllerBase
    {
        private readonly IBaseService<Dto, Entity> baseService;
        private readonly IMapper mapper;

        public BaseController(IBaseService<Dto, Entity> baseService, IMapper mapper)
        {
            this.baseService = baseService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await baseService.GetAll();
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

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var result = await baseService.GetById(id);
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

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] Dto dto)
        {
            var result = await baseService.Insert(dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            if (result.Success)
            {
                return StatusCode(201, result);
            }
            return BadRequest(result);
        }


        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id,[FromBody]Dto dto)
        {
            var result = await baseService.Update(id, dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            if (result.Success)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Update(int id)
        {
            var result = await baseService .Remove(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
