using Catalog.Application;
using Catalog.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<ItemDto> Get(Guid id)
    {
        return await _itemService.GetAsync(id);
    }

    [HttpPost]
    public async Task<ItemDto> Create(ItemDto item)
    {
        return await _itemService.AddAsync(item);
    }

    [HttpDelete]
    public async Task Delete(Guid id)
    {
        await _itemService.RemoveAsync(id);
    }
}