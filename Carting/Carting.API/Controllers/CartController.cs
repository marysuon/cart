using Carting.API.ApplicationLayer;
using Carting.API.ApplicationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Carting.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet(Name = "Get")]
        public CartDto Get(Guid id)
        {
            return _cartService.Get(id);
        }

        [HttpDelete(Name = "Delete")]
        public void Delete(Guid id)
        {
            _cartService.Remove(id);
        }

        [HttpPost(Name = "Create")]
        public CartDto Create(CartDto cart)
        {
            return _cartService.Add(cart);
        }
    }
}