using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionArcExample.Application;
using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.WebAPI
{

    [ApiController]
    [Route("api/nhb/[controller]")]
    public class StoreController : BaseController<StoreDto, Store>
    {

        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService, IMapper mapper) : base(storeService)
        {
            this.storeService = storeService;
        }

        [HttpPost("Increment")]
        public async Task<BaseResponse<StoreDto>> Increment(int id)
        {
            var response = await storeService.IncrementInventory(id);
            return response;
        }
    }
}