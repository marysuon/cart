using AutoMapper;
using Carting.Application.Models;
using Carting.Application.Repository;
using Carting.Domain.Models;

namespace Carting.Application
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

        public CartDto Add()
        {
            var cart = Cart.Create();
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