using AutoMapper;
using Carting.API.ApplicationLayer.Models;
using Carting.API.ApplicationLayer.Repository;
using Carting.API.DomainLayer.Models;

namespace Carting.API.ApplicationLayer
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IMapper _mapper;

        public CartService(IRepository<Cart> cartRepository, IMapper mapper)
        {
            this._cartRepository = cartRepository;
            _mapper = mapper;
        }

        public CartDto Add(CartDto dto)
        {
            var cart = Cart.Create();

            foreach (var item in dto.Items)
            {
                cart.AddItem(_mapper.Map<ItemDto, Item>(item));
            }

            _cartRepository.Add(cart);

            return _mapper.Map<Cart, CartDto>(cart);
        }

        public void Remove(Guid id)
        {
            _cartRepository.Remove(id);
        }

        public CartDto Get(Guid id)
        {
            var cart = _cartRepository.FindById(id);

            return _mapper.Map<Cart, CartDto>(cart);
        }
    }
}