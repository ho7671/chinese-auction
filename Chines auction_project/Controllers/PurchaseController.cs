using AutoMapper;
using Chines_auction_project.BLL;
using Chines_auction_project.Modells;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Chines_auction_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseController:ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IPurchaseService purchaseService;
        public PurchaseController(IMapper mapper, IPurchaseService purchaseService)
        {
            this.mapper = mapper;
            this.purchaseService = purchaseService;
        }
        [HttpGet("GetAllPurchase")]

        public async Task<ActionResult<Purchase>> GetAllPurchase()
        {
            var p =await purchaseService.GetAllPurchase();
            return p == null ? NotFound() : Ok(p);
        }
        //public Purchase GetPurchaseByPresent(Present present);
        [HttpGet("GetPurchaseById/{userId}")]

        public async Task<ActionResult<Purchase>> GetAllPurchaseById(int userId)
        {
            var p = await purchaseService.GetAllPurchaseById(userId);
            return p == null ? NotFound() : Ok(p);
        }
        [HttpGet("GetShoppingCartById/{userId}")]

        public async Task<ActionResult<Purchase>> GetShoppingCartById(int userId)
        {
            var p = await purchaseService.GetShoppingCartById(userId);
            return p == null ? NotFound() : Ok(p);
        }

        [HttpPost("AddPurchase")]
        public async Task<ActionResult<Purchase>> AddPurchase(Purchase purchase)
        {
            var p = mapper.Map<Purchase>(purchase);
            return p == null ? NotFound() : Ok(await purchaseService.AddPurchase(p));
        }//change thr status and pay

    }
}
