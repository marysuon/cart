using Carting.Application;
using Carting.Application.Models;
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
    }
}