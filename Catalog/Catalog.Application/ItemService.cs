using AutoMapper;
using Catalog.Application.Models;
using Catalog.Application.Repository;
using Catalog.Domain.Models;

namespace Catalog.Application;

public class ItemService : IItemService
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public ItemService(IRepository<Item> itemRepository, IMapper mapper)
    {
        this._itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<ItemDto> AddAsync(ItemDto itemDto)
    {
        var item = _mapper.Map<ItemDto, Item>(itemDto);
            
        await _itemRepository.AddAsync(item);

        return _mapper.Map<Item, ItemDto>(item);
    }

    public async Task RemoveAsync(Guid id)
    {
        await _itemRepository.RemoveAsync(id);
    }

    public async Task<ItemDto> GetAsync(Guid id)
    {
        var item = await _itemRepository.FindByIdAsync(id);

        return _mapper.Map<Item, ItemDto>(item);
    }
}